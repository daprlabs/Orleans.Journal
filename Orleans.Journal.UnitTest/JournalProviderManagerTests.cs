// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JournalProviderManagerTests.cs" company="">
//   
// </copyright>
// <summary>
//   Tests for <see cref="JournalProviderManager" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.UnitTests
{
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <see cref="JournalProviderManager"/>.
    /// </summary>
    [TestClass]
    public class JournalProviderManagerTests
    {
        /// <summary>
        /// Verifies that <see cref="JournalProviderAttributeMissingException"/> is thrown when a provider
        /// attribute is not present on a type.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(JournalProviderAttributeMissingException))]
        public async Task GetProviderForClassWithoutAnnotation()
        {
            await JournalProviderManager.Manager.GetProvider(typeof(JournalProviderManagerTests));
        }

        /// <summary>
        /// Verifies that <see cref="JournalProviderConfigurationNotFoundException"/> is thrown when a provider
        /// specified in an attribute is not found.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(JournalProviderConfigurationNotFoundException))]
        public async Task GetProviderForClassWithMissingProvider()
        {
            await JournalProviderManager.Manager.GetProvider(typeof(ProviderDoesNotExist));
        }

        /// <summary>
        /// Verifies that a provider is correctly identified for a type based upon the
        /// <see cref="JournalProviderAttribute"/>, and that the provider is correctly initialized when calling
        /// <see cref="JournalProviderManager.GetProvider"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        [TestMethod]
        public async Task GetProviderWithConfiguration()
        {
            var config = JournalProviderConfiguration.ProviderNameKey + "=" + typeof(TestJournalProvider).AssemblyQualifiedName + ";SomeSetting=X";
            JournalProviderManager.Manager.GetSettingDelegate = providerName => string.Equals(providerName, "DefaultJournal") ? config : null;

            var provider = await JournalProviderManager.Manager.GetProvider(typeof(Journaled));
            Assert.IsInstanceOfType(provider, typeof(TestJournalProvider), "Should get the TestJournalProvider provider.");

            // Verify that it was initialized and intiialized correctly.
            var testProvider = (TestJournalProvider)provider;
            Assert.IsTrue(testProvider.Parameters.ContainsKey("SomeSetting"));
            Assert.IsTrue(string.Equals(testProvider.Parameters["SomeSetting"], "X"));
        }

        /// <summary>
        /// A class whose <see cref="JournalProviderAttribute"/> specifies a provider which does not exist.
        /// </summary>
        [JournalProvider("DoesNotExist")]
        public class ProviderDoesNotExist
        {
        }

        /// <summary>
        /// A class whose <see cref="JournalProviderAttribute"/> specifies a provider which exists in the testing scenario.
        /// </summary>
        [JournalProvider("DefaultJournal")]
        public class Journaled
        {
        }
    }
}
