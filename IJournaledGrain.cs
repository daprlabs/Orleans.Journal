// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IJournaledGrain.cs" company="">
//   
// </copyright>
// <summary>
//   The interface for grains which leverage journaling.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    /// <summary>
    /// The interface for grains which leverage journaling.
    /// </summary>
    /// <typeparam name="TState">
    /// The underlying state type for this grain.
    /// </typeparam>
    public interface IJournaledGrain<TState>
    {
        /// <summary>
        /// Returns the current state of this grain.
        /// </summary>
        /// <returns>
        /// The current state of this grain.
        /// </returns>
        IJournaledState<TState> GetState();
    }
}