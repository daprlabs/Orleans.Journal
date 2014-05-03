// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalProviderAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The journal provider attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System;

    /// <summary>
    /// The journal provider attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class JournalProviderAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalProviderAttribute"/> class.
        /// </summary>
        /// <param name="providerName">
        /// The provider name.
        /// </param>
        public JournalProviderAttribute(string providerName)
        {
            this.ProviderName = providerName;
        }

        /// <summary>
        /// Gets or sets the provider name.
        /// </summary>
        public string ProviderName { get; set; }
    }
}

