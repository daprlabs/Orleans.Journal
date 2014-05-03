// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournaledGrainBase.cs" company="">
//   
// </copyright>
// <summary>
//   A base class for grains which leverage journaling.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System.Threading.Tasks;

    using Orleans;

    /// <summary>
    /// A base class for grains which leverage journaling.
    /// </summary>
    /// <typeparam name="TGrain">
    /// The type of the grain which inherits from this class.
    /// </typeparam>
    /// <typeparam name="TState">
    /// The underlying type of the state for the subclass.
    /// </typeparam>
    public abstract class JournaledGrainBase<TGrain, TState> : GrainBase<IJournaledState<TState>>, IJournaledGrain<TState>
        where TGrain : GrainBase<IJournaledState<TState>>, IJournaledGrain<TState>, IGrain
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournaledGrainBase{TGrain,TState}"/> class.
        /// </summary>
        protected JournaledGrainBase()
        {
            this.JournalWritesBetweenSnapshots = 100;
        }  

        /// <summary>
        /// Gets or sets the journal.
        /// </summary>
        public GrainJournal<TGrain, TState> Journal { get; set; }

        /// <summary>
        /// Gets or sets the journal messages between snapshots.
        /// </summary>
        public uint JournalWritesBetweenSnapshots { get; set; }

        /// <summary>
        /// Returns the current state of this grain.
        /// </summary>
        /// <returns>
        /// The current state of this grain.
        /// </returns>
        public IJournaledState<TState> GetState()
        {
            return this.State;
        }

        /// <summary>
        /// This method is called at the end of the process of activating a grain.
        ///             It is called before any messages have been dispatched to the grain.
        ///             For grains with declared persistent state, this method is called after the State property has been populated.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public override async Task ActivateAsync()
        {
            var logger = this.GetLogger("JournaledGrainBase<" + typeof(TGrain).FullName + ">");

            // Initialize the journal and replay journaled messages.
            await GrainJournal<TGrain, TState>.Initialized();
            this.Journal = new GrainJournal<TGrain, TState>(this as TGrain, this.JournalWritesBetweenSnapshots);
            logger.Info(0, "ActivateAsync recovering from event id {0}.", this.Journal.LastJournaledEventId);
            await this.Journal.ReplayUnappliedEvents();
            logger.Info(0, "ActivateAsync recovered to event id {0}.", this.Journal.LastJournaledEventId);
            await base.ActivateAsync();
        }
    }
}