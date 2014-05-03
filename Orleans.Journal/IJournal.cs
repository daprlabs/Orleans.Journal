// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IJournalProvider.cs" company="">
//   
// </copyright>
// <summary>
//   Describes an event journal provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes an event journal provider.
    /// </summary>
    public interface IJournal
    {
        #region Public Methods and Operators

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
        Task<IEvent> Append(byte[] @event, ulong id);

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
        IObservable<IEvent> ReadFrom(ulong id = 0);

        /// <summary>
        /// Clears the journal up to and including, the provided <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id to clear up to.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        Task Clear(ulong id);
        #endregion
    }
}