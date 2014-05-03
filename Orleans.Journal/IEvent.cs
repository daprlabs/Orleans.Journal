// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEvent.cs" company="">
//   
// </copyright>
// <summary>
//   The event interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    /// <summary>
    /// The event interface.
    /// </summary>
    public interface IEvent
    {
        #region Public Properties

        /// <summary>
        /// Gets the event.
        /// </summary>
        byte[] Event { get; }

        /// <summary>
        /// Gets the event id.
        /// </summary>
        ulong EventId { get; }

        #endregion
    }
}