// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalProviderConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The journal provider configuration parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// The journal provider configuration parser.
    /// </summary>
    /// <remarks>
    /// The only required key in the string is "Provider". Provider-specific settings can be provided also.</remarks>
    /// <example>
    /// Here is an example configuration string:
    /// Provider=Orleans.Journal.AzureTable.AzureTableJournal,Orleans.Journal.AzureTable;Table=grainJournal;ConnectionStringSetting=JournalConnection
    /// </example>
    public static class JournalProviderConfiguration
    {
        /// <summary>
        /// The provider name key, holding the type name of the provider, including the assembly.
        /// </summary>
        /// <example>
        /// Orleans.Journal.AzureTable.AzureTableJournal, Orleans.Journal.AzureTable
        /// </example>
        public const string ProviderNameKey = "Provider";

        /// <summary>
        /// Returns an <see cref="IJournalProvider"/> with the provided <paramref name="configuration"/>.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <returns>
        /// An <see cref="IJournalProvider"/> with the provided <paramref name="configuration"/>.
        /// </returns>
        public static async Task<IJournalProvider> GetProviderFromConfiguration(string configuration)
        {
            var config = ParseConfigurationString(configuration);
            var providerTypeName = config[ProviderNameKey];
            var providerType = Type.GetType(providerTypeName, throwOnError: true);
            var provider = (IJournalProvider)Activator.CreateInstance(providerType);
            await provider.Initialize(config);
            return provider;
        }

        /// <summary>
        /// Parses the provided <paramref name="configuration"/>, returning the parsed result.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <returns>
        /// The result of parsing the provided <paramref name="configuration"/>.
        /// </returns>
        public static Dictionary<string, string> ParseConfigurationString(string configuration)
        {
            // Parse out entries in the form of Key1=Value1;Key2=Value2; (and so on).
            return Regex.Matches(configuration, "([^=;]+)(=([^;]*))?").Cast<Match>().ToDictionary(x => x.Groups[1].Value, x => x.Groups[3].Value);
        }
    }
}