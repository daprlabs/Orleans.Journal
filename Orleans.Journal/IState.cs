// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IState.cs" company="">
//   
// </copyright>
// <summary>
//   A generic, parameterized <see cref="IGrainState" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using Orleans;

    /// <summary>
    /// A generic, parameterized <see cref="IGrainState"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The underlying state type.
    /// </typeparam>
    public interface IState<T> : IGrainState
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        T Value { get; set; }
    }
}