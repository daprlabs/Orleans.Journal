// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStackGrain.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IStackGrain type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestGrainInterfaces
{
    using System;
    using System.Threading.Tasks;

    using Orleans;

    /// <summary>
    /// The TestGrain interface.
    /// </summary>
    public interface IStackGrain : IGrain
    {
        /// <summary>
        /// Returns the size of the stack.
        /// </summary>
        /// <returns>
        /// The size of the stack.
        /// </returns>
        Task<int> GetSize();

        /// <summary>
        /// Pushes a value onto the stack.
        /// </summary>
        /// <param name="value">The value to push onto the stack.</param>
        /// <returns>A <see cref="Task"/> representing the work performed.</returns>
        Task Push(int value);

        /// <summary>
        /// Pops a value from the stack.
        /// </summary>
        /// <returns>The value on the top of the stack, or an <see cref="Exception"/> if the stack is empty.</returns>
        Task<int> Pop();
    }
}
