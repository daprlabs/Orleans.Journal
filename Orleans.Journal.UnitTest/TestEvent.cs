// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEvent.cs" company="">
//   
// </copyright>
// <summary>
//   A trivial implmentation of <see cref="IEvent" /> for testing purposes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.UnitTests
{
    /// <summary>
    /// A trivial implmentation of <see cref="IEvent"/> for testing purposes.
    /// </summary>
    internal class TestEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the event payload.
        /// </summary>
        public byte[] Event { get; set; }

        /// <summary>
        /// Gets or sets the event id.
        /// </summary>
        public ulong EventId { get;set; }
    }
}