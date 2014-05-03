// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalProviderConfigurationTests.cs" company="">
//   
// </copyright>
// <summary>
//   Tests for <see cref="JournalProviderConfiguration" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.UnitTests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <see cref="JournalProviderConfiguration"/>.
    /// </summary>
    [TestClass]
    public class JournalProviderConfigurationTests
    {
        /// <summary>
        /// A basic test for <see cref="JournalProviderConfiguration.GetProviderFromConfiguration"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        [TestMethod]
        public async Task GetProviderFromConfiguration_Basic()
        {
            var providerName = typeof(TestJournalProvider).FullName + "," + typeof(TestJournalProvider).Assembly.FullName;
            var configuration = "Provider=" + providerName;
            var result = (TestJournalProvider)await JournalProviderConfiguration.GetProviderFromConfiguration(configuration);
            Assert.IsTrue(result.IsInitialized);
            Assert.IsNotNull(result.Parameters);
            Assert.AreEqual(result.Parameters[JournalProviderConfiguration.ProviderNameKey], providerName);
        }

        /// <summary>
        /// A basic test for <see cref="JournalProviderConfiguration.GetProviderFromConfiguration"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(TypeLoadException))]
        public async Task GetProviderFromConfiguration_BadProviderType()
        {
            var providerName = "SomeTypeWhichDoesNotExist";
            var configuration = "Provider=" + providerName;
            await JournalProviderConfiguration.GetProviderFromConfiguration(configuration);
        }

        /// <summary>
        /// A basic test for <see cref="JournalProviderConfiguration.GetProviderFromConfiguration"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(TestJournalProvider.IntentionalException))]
        public async Task GetProviderFromConfiguration_BadConfig()
        {
            var providerName = typeof(TestJournalProvider).AssemblyQualifiedName;
            var configuration = "Provider=" + providerName + ";" + TestJournalProvider.ThrowOnInitialize + "=true";
            await JournalProviderConfiguration.GetProviderFromConfiguration(configuration);
        }

        /// <summary>
        /// A basic test for <see cref="JournalProviderConfiguration.GetProviderFromConfiguration"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(TestJournalProvider.IntentionalException))]
        public async Task GetProviderFromConfiguration_ThrowOnCreate()
        {
            var providerName = typeof(TestJournalProvider).AssemblyQualifiedName;
            var configuration = "Provider=" + providerName + ";" + TestJournalProvider.ThrowOnCreate + "=true";
            var provider = await JournalProviderConfiguration.GetProviderFromConfiguration(configuration);
            provider.Create("someStream");
        }
    }
}
