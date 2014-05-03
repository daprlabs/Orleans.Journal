// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestJournalProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The test journal provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The test journal provider.
    /// </summary>
    public class TestJournalProvider : IJournalProvider
    {
        /// <summary>
        /// The configuration parameter name for the value which determines whether this
        /// instance should throw on a call to the <see cref="Initialize"/> method.
        /// </summary>
        public const string ThrowOnInitialize = "ThrowOnInitialize";

        /// <summary>
        /// The configuration parameter name for the value which determines whether this
        /// instance should throw on a call to the <see cref="Create"/> method.
        /// </summary>
        public const string ThrowOnCreate = "ThrowOnCreate";

        /// <summary>
        /// Gets or sets a value indicating whether this instance is initialized.
        /// </summary>
        public bool IsInitialized { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// Initializes this instance with the provided <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">The initialization parameters.</param>
        /// <returns>A <see cref="Task"/> representing the work performed.</returns>
        public async Task Initialize(Dictionary<string, string> parameters)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            if (this.IsInitialized)
            {
                throw new InvalidOperationException("Instance already initialized.");
            }

            this.IsInitialized = true;
            this.Parameters = parameters;
            string val;
            if (this.Parameters.TryGetValue(ThrowOnInitialize, out val) &&
                string.Equals(val, "true", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new IntentionalException("Throwing from Initialize.");
            }
        }

        /// <summary>
        /// Returns a new <see cref="IJournal"/>, initialized with the provided <paramref name="streamId"/>.
        /// </summary>
        /// <param name="streamId">
        /// The stream id.
        /// </param>
        /// <returns>
        /// A new <see cref="IJournal"/>, initialized with the provided <paramref name="streamId"/>.
        /// </returns>
        public IJournal Create(string streamId)
        {
            if (!this.IsInitialized)
            {
                throw new InvalidOperationException("Instance has not been initialized.");
            }

            string val;
            if (this.Parameters.TryGetValue(ThrowOnCreate, out val) &&
                string.Equals(val, "true", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new IntentionalException("Throwing from Create.");
            }

            return new TestJournal();
        }

        /// <summary>
        /// The intentional exception.
        /// </summary>
        public class IntentionalException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="IntentionalException"/> class.
            /// </summary>
            /// <param name="message">
            /// The message.
            /// </param>
            public IntentionalException(string message)
                : base(message)
            {
            }
        }
    }
}