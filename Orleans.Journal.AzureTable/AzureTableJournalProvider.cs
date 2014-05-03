// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AzureTableJournalProvider.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AzureTableJournalProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.AzureTable
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    /// The Azure table journal provider.
    /// </summary>
    public class AzureTableJournalProvider : IJournalProvider
    {
        /// <summary>
        /// The connection string setting name.
        /// </summary>
        public const string ConnectionStringSettingName = "ConnectionStringSetting";

        /// <summary>
        /// The table setting name.
        /// </summary>
        public const string TableSettingName = "Table";

        /// <summary>
        /// The table.
        /// </summary>
        private CloudTable table;

        /// <summary>
        /// Initializes this instance with the provided <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">The initialization parameters.</param>
        /// <returns>A <see cref="Task"/> representing the work performed.</returns>
        public async Task Initialize(Dictionary<string, string> parameters)
        {
            var connStringSettingName = parameters[ConnectionStringSettingName];
            if (string.IsNullOrWhiteSpace(connStringSettingName))
            {
                throw new ArgumentException(ConnectionStringSettingName);
            }

            var tableName = parameters[TableSettingName];
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException(TableSettingName);
            }

            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(connStringSettingName));
            var client = account.CreateCloudTableClient();
            this.table = client.GetTableReference(tableName);
            await this.table.CreateIfNotExistsAsync();
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
            return new AzureTableJournal(streamId, this.table);
        }
    }
}
