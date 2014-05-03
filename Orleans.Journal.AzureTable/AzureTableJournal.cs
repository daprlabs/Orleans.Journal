// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AzureTableJournal.cs" company="">
//   
// </copyright>
// <summary>
//   The Azure Table Service journal provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.AzureTable
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage.Table;
    
    /// <summary>
    /// The Azure Table Service journal provider.
    /// </summary>
    public class AzureTableJournal : IJournal
    {
        #region Fields

        /// <summary>
        ///     The event store.
        /// </summary>
        private readonly CloudTable store;

        /// <summary>
        ///     The partition id.
        /// </summary>
        private readonly string partitionKey;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureTableJournal"/> class.
        /// </summary>
        /// <param name="partitionKey">
        /// The partition key.
        /// </param>
        /// <param name="store">
        /// The event store.
        /// </param>
        public AzureTableJournal(string partitionKey, CloudTable store)
        {
            this.partitionKey = partitionKey;
            this.store = store;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Append the provided <paramref name="event"/> to the journal.
        /// </summary>
        /// <param name="event">
        /// The event.
        /// </param>
        /// <param name="id">
        /// The id of the event being appended.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public async Task<IEvent> Append(byte[] @event, ulong id)
        {
            var tableEvent = new EventEntity(this.partitionKey, id) { Event = @event };

            await this.store.ExecuteAsync(TableOperation.Insert(tableEvent));

            return tableEvent;
        }

        /// <summary>
        /// Returns an observable, ordered sequence of events from the journal, beginning with the event with the
        ///     lowest identifier greater than <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The event id to begin enumeration at. Enumeration will begin at the first event with an identifier
        ///     greater than <paramref name="id"/>.
        /// </param>
        /// <returns>
        /// An <see cref="IObservable{T}"/> sequence of events from the journal.
        /// </returns>
        public IObservable<IEvent> ReadFrom(ulong id = 0)
        {
            var query = GreaterThan(this.partitionKey, id);
            return this.store.ExecuteAsObservable(query);
        }

        /// <summary>
        /// Clears the journal up to and including, the provided <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id to clear up to.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the work performed.
        /// </returns>
        public async Task Clear(ulong id)
        {
            var query = LessThanOrEqual(this.partitionKey, id);
            
            // Azure Table Service supports batches of 100, so we chop the results up and batch the deletions.
            await this.store.ExecuteAsObservable(query).Buffer(100).ForEachAsync(
                async entryBatch =>
                {
                    var batchOperation = new TableBatchOperation();
                    foreach (var entry in entryBatch)
                    {
                        batchOperation.Add(TableOperation.Delete(entry));
                    }

                    await this.store.ExecuteBatchAsync(batchOperation);
                });
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the canonical <see cref="string"/> for the provided <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The canonical <see cref="string"/> for the provided <paramref name="id"/>.
        /// </returns>
        private static string GetIdString(ulong id)
        {
            return id.ToString("X16");
        }

        /// <summary>
        /// Returns a query for all entities with an id greater than to the provided <paramref name="id"/>.
        /// </summary>
        /// <param name="partition">
        /// The partition key.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// A query for all entities with an id greater than to the provided <paramref name="id"/>.
        /// </returns>
        private static TableQuery<EventEntity> GreaterThan(string partition, ulong id)
        {
            return
                new TableQuery<EventEntity>().Where(
                    TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partition),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThan, GetIdString(id))));
        }

        /// <summary>
        /// Returns a query for all entities with an id less than or equal to the provided <paramref name="id"/>.
        /// </summary>
        /// <param name="partition">
        /// The partition key.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// A query for all entities with an id less than or equal to the provided <paramref name="id"/>.
        /// </returns>
        private static TableQuery<EventEntity> LessThanOrEqual(string partition, ulong id)
        {
            return
                new TableQuery<EventEntity>().Where(
                    TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partition),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThanOrEqual, GetIdString(id))));
        }

        #endregion
    }
}