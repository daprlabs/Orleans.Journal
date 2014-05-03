// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalProviderManager.cs" company="">
//   
// </copyright>
// <summary>
//   The journal provider manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure;

    /// <summary>
    /// The journal provider manager.
    /// </summary>
    public class JournalProviderManager
    {
        /// <summary>
        /// The cache of grain journal providers.
        /// </summary>
        private readonly ConcurrentDictionary<Type, string> grainJournalProviders;

        /// <summary>
        /// The cache of journal providers.
        /// </summary>
        private readonly ConcurrentDictionary<string, IJournalProvider> providers;

        /// <summary>
        /// Initializes static members of the <see cref="JournalProviderManager"/> class.
        /// </summary>
        static JournalProviderManager()
        {
            Manager = new JournalProviderManager();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalProviderManager"/> class.
        /// </summary>
        public JournalProviderManager()
        {
            this.grainJournalProviders = new ConcurrentDictionary<Type, string>();
            this.providers = new ConcurrentDictionary<string, IJournalProvider>();
            this.GetSettingDelegate = CloudConfigurationManager.GetSetting;
        }

        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        public static JournalProviderManager Manager { get; set; }

        /// <summary>
        /// Gets or sets the delegate used to retrieve settings given a provider name.
        /// </summary>
        /// <remarks>The default value is <see cref="CloudConfigurationManager.GetSetting"/>.</remarks>
        public Func<string, string> GetSettingDelegate { get; set; }

        /// <summary>
        /// Returns the <see cref="IJournalProvider"/> for the provided <paramref name="grainType"/>.
        /// </summary>
        /// <param name="grainType">The grain type</param>
        /// <returns>
        /// The <see cref="IJournalProvider"/> for the provided <paramref name="grainType"/>.
        /// </returns>
        public async Task<IJournalProvider> GetProvider(Type grainType)
        {
            var providerName = this.grainJournalProviders.GetOrAdd(grainType, GetJournalProviderForGrainType);
            IJournalProvider result;
            if (!this.providers.TryGetValue(providerName, out result))
            {
                var newProvider = await this.GetJournalProvider(providerName);
                result = this.providers.GetOrAdd(providerName, _ => newProvider);
            }

            return result;
        }

        /// <summary>
        /// Returns the <see cref="IJournalProvider"/> for the provided <paramref name="grainType"/>.
        /// </summary>
        /// <param name="grainType">The grain type</param>
        /// <returns>
        /// The <see cref="IJournalProvider"/> for the provided <paramref name="grainType"/>.
        /// </returns>
        private static string GetJournalProviderForGrainType(Type grainType)
        {
            var attr = grainType.GetCustomAttribute<JournalProviderAttribute>();
            if (attr == null)
            {
                throw JournalProviderAttributeMissingException.Create(grainType);
            }

            return attr.ProviderName;
        }

        /// <summary>
        /// Returns an <see cref="IJournalProvider"/> created from configuration for <paramref name="providerName"/>.
        /// </summary>
        /// <param name="providerName">
        /// The provider name.
        /// </param>
        /// <returns>
        /// An <see cref="IJournalProvider"/> created from configuration for <paramref name="providerName"/>.
        /// </returns>
        private async Task<IJournalProvider> GetJournalProvider(string providerName)
        {
            var configuration = this.GetSettingDelegate(providerName);
            if (configuration == null)
            {
                throw JournalProviderConfigurationNotFoundException.Create(providerName);
            }

            return await JournalProviderConfiguration.GetProviderFromConfiguration(configuration);
        }
    }
}