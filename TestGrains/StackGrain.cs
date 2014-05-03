// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StackGrain.cs" company="">
//   
// </copyright>
// <summary>
//   The stack grain.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestGrains
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Orleans.Journal;

    using TestGrainInterfaces;

    /// <summary>
    /// The stack grain.
    /// </summary>
    [JournalProvider("DefaultJournal")]
    public class StackGrain : JournaledGrainBase<StackGrain, Stack<int>>, IStackGrain
    {
        /// <summary>
        /// Returns the size of the stack.
        /// </summary>
        /// <returns>
        /// The size of the stack.
        /// </returns>
        public async Task<int> GetSize()
        {
            return this.State.Value.Count;
        }

        /// <summary>
        /// Pushes a value onto the stack.
        /// </summary>
        /// <param name="value">The value to push onto the stack.</param>
        /// <returns>A <see cref="Task"/> representing the work performed.</returns>
        public async Task Push(int value)
        {
            await this.Journal.WriteJournal();
            this.State.Value.Push(value);
        }

        /// <summary>
        /// Pops a value from the stack.
        /// </summary>
        /// <returns>The value on the top of the stack, or an <see cref="Exception"/> if the stack is empty.</returns>
        public async Task<int> Pop()
        {
            await this.Journal.WriteJournal();
            return this.State.Value.Pop();
        }
    }
}
