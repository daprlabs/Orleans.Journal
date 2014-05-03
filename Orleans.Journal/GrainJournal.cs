// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Orleans.Journal.cs" company="">
//   
// </copyright>
// <summary>
//   A journal of requests made against a grain.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    using Orleans;
    using Orleans.Serialization;

    /// <summary>
    /// A journal of requests made against a grain.
    /// </summary>
    /// <typeparam name="TGrain">
    /// The type of the grain.
    /// </typeparam>
    /// <typeparam name="TState">
    /// The underlying state type for the grain.
    /// </typeparam>
    public class GrainJournal<TGrain, TState>
        where TGrain : GrainBase<IJournaledState<TState>>, IJournaledGrain<TState>, IGrain
    {
        /// <summary>
        /// The journal provider.
        /// </summary>
        private static readonly Task<IJournalProvider> JournalProvider = JournalProviderManager.Manager.GetProvider(typeof(TGrain));

        /// <summary>
        /// The number of journal writes which should occur between snapshots.
        /// </summary>
        private readonly uint journalWritesBetweenSnapshots;

        /// <summary>
        /// The grain which this journal represents.
        /// </summary>
        private readonly TGrain grain;

        /// <summary>
        /// The journal.
        /// </summary>
        private readonly IJournal journal;

        /// <summary>
        /// The number of events written since the last snapshot.
        /// </summary>
        private uint journaledSinceLastSnapshot;

        /// <summary>
        /// Initializes a new instance of the <see cref="Orleans.Journal{TGrain,TState}"/> class.
        /// </summary>
        /// <param name="grain">The grain instance.</param>
        /// <param name="journalWritesBetweenSnapshots">
        /// The number of journal writes which should occur between snapshots.
        /// </param>
        public GrainJournal(TGrain grain, uint journalWritesBetweenSnapshots = 100)
        {
            this.grain = grain;
            string extension;
            var primaryKey = grain.GetPrimaryKey(out extension);
            var extensionString = string.IsNullOrWhiteSpace(extension) ? string.Empty : "_" + extension;
            var streamId = typeof(TGrain).FullName + "_" + primaryKey.ToString("N") + extensionString;
            this.journal = JournalProvider.Result.Create(streamId);
            this.journalWritesBetweenSnapshots = journalWritesBetweenSnapshots;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the journal is being replayed.
        /// </summary>
        public bool IsBeingReplayed { get; set; }

        /// <summary>
        /// Gets the event id of the last journal entry written.
        /// </summary>
        public ulong LastJournaledEventId
        {
            get
            {
                return this.State.CurrentEventId;
            }

            private set
            {
                this.State.CurrentEventId = value;
            }
        }

        /// <summary>
        /// Gets the grain state.
        /// </summary>
        private IJournaledState<TState> State
        {
            get
            {
                return this.grain.GetState();
            }
        }

        /// <summary>
        /// Returns a <see cref="Task"/> which completes when this type is initialized.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> which completes when this type is initialized.
        /// </returns>
        public static Task Initialized()
        {
            return JournalProvider;
        }

        /// <summary>
        /// Journal the current request.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task WriteJournal()
        {
            if (!this.IsBeingReplayed)
            {
                if (++this.journaledSinceLastSnapshot % this.journalWritesBetweenSnapshots == 0)
                {
                    await this.WriteSnapshot();
                }

                var currentRequest = GrainExecutionHelper.CurrentRequest(this.grain);
                if (currentRequest != null)
                {
                    var bytes = SerializationManager.SerializeToByteArray(currentRequest);
                    var nextEventId = this.LastJournaledEventId + 1;
                    await this.journal.Append(bytes, nextEventId);
                    this.LastJournaledEventId = nextEventId;
                }
            }
        }

        /// <summary>
        /// Replay all events since the last snapshot.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public async Task ReplayUnappliedEvents()
        {
            if (!this.IsBeingReplayed)
            {
                try
                {
                    this.IsBeingReplayed = true;
                    var currentEventId = this.LastJournaledEventId;
                    await this.journal.ReadFrom(currentEventId).ForEachAsync(
                        async @event =>
                        {
                            // Update internal state.
                            if (@event.EventId > this.LastJournaledEventId)
                            {
                                this.LastJournaledEventId = @event.EventId;
                            }

                            // Deserialize the event.
                            var request = SerializationManager.DeserializeFromByteArray<MethodInvocation>(@event.Event);

                            // Apply the event.
                            await GrainExecutionHelper.ApplyRequest(this.grain, request);
                        });
                }
                finally
                {
                    this.IsBeingReplayed = false;
                }
            }
        }

        /// <summary>
        /// Snapshot the state of the grain.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public async Task WriteSnapshot()
        {
            await this.State.WriteStateAsync();
        }

        /// <summary>
        /// Delete all known journal entries and snapshots of the grain.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public async Task Delete()
        {
            await this.journal.Clear(this.LastJournaledEventId + 1);
            await this.State.ClearStateAsync();
        }
    }
}
