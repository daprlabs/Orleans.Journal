// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IJournalProvider.cs" company="">
//   
// </copyright>
// <summary>
//   Interface for <see cref="IJournalProvider" /> factories.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for <see cref="IJournal"/> factories.
    /// </summary>
    public interface IJournalProvider
    {
        /// <summary>
        /// Initializes this instance with the provided <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">The initialization parameters.</param>
        /// <returns>A <see cref="Task"/> representing the work performed.</returns>
        Task Initialize(Dictionary<string, string> parameters);

        /// <summary>
        /// Returns a new <see cref="IJournal"/>, initialized with the provided <paramref name="streamId"/>.
        /// </summary>
        /// <param name="streamId">
        /// The stream id.
        /// </param>
        /// <returns>
        /// A new <see cref="IJournal"/>, initialized with the provided <paramref name="streamId"/>.
        /// </returns>
        IJournal Create(string streamId);
    }
}
