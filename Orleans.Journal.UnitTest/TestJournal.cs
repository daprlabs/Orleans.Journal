// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestJournal.cs" company="">
//   
// </copyright>
// <summary>
//   The test journal.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.UnitTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.ObjectModel;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The test journal.
    /// </summary>
    public class TestJournal : IJournal
    {
        /// <summary>
        /// The journal events.
        /// </summary>
        private readonly ConcurrentDictionary<ulong, TestEvent> events = new ConcurrentDictionary<ulong, TestEvent>();
        
        /// <summary>
        /// Append the provided <paramref name="event"/> to the journal.
        /// </summary>
        /// <param name="event">
        /// The event.
        /// </param>
        /// <param name="id">
        /// The id of the event being appended.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public async Task<IEvent> Append(byte[] @event, ulong id)
        {
            var appended = new TestEvent { Event = @event, EventId = id };
            if (!this.events.TryAdd(id, appended))
            {
                throw EventExistsException.Create(id);
            }

            return appended;
        }

        /// <summary>
        /// Returns an observable, ordered sequence of events from the journal, beginning with the event with the
        ///     lowest identifier greater than <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The event id to begin enumeration at. Enumeration will begin at the first event with an identifier
        ///     greater than <paramref name="id"/>.
        /// </param>
        /// <returns>
        /// An <see cref="IObservable{T}"/> sequence of events from the journal.
        /// </returns>
        public IObservable<IEvent> ReadFrom(ulong id = 0)
        {
            return Observable.Create<IEvent>(
                async observer =>
                {
                    try
                    {
                        TestEvent @event;
                        while (this.events.TryGetValue(id, out @event))
                        {
                            observer.OnNext(@event);
                            id++;
                        }

                        observer.OnCompleted();
                    }
                    catch (Exception exception)
                    {
                        observer.OnError(exception);
                    }
                });
        }

        /// <summary>
        /// Clears the journal up to and including, the provided <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id to clear up to.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public async Task Clear(ulong id)
        {
            await Task.Factory.StartNew(
                () =>
                {
                    for (var i = (ulong)0; i <= id; i++)
                    {
                        TestEvent value;
                        events.TryRemove(i, out value);
                    }
                });
        }
    }
}