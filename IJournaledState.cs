// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IJournaledState.cs" company="Dapr Labs">
//   Copyright 2014, Dapr Labs Pty. Ltd.
// </copyright>
// <summary>
//   A parameterized <see cref="IGrainState" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using Orleans;

    /// <summary>
    /// A parameterized <see cref="IGrainState"/> with added support for event journaling.
    /// </summary>
    /// <typeparam name="T">
    /// The underlying state type.
    /// </typeparam>
    public interface IJournaledState<T> : IState<T>
    {
        /// <summary>
        /// Gets or sets the current journal event id.
        /// </summary>
        ulong CurrentEventId { get; set; }
    }
}
