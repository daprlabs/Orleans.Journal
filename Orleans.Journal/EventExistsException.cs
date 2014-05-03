// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventExistsException.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the EventExistsException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Orleans.Journal
{
    using System.Runtime.Serialization;

    public class EventExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventExistsException"/> class.
        /// </summary>
        public EventExistsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventExistsException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public EventExistsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventExistsException"/> class.
        /// </summary>
        /// <param name="eventId">
        /// The event id.
        /// </param>
        /// <returns>
        /// A new instance of the <see cref="EventExistsException"/> class.
        /// </returns>
        public static EventExistsException Create(ulong eventId)
        {
            return new EventExistsException("Event " + eventId + " already exists in the journal.");
        }
    }
}
