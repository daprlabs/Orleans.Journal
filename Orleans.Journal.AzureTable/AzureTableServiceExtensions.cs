// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AzureTableServiceExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   Extension methods for the Azure Table Service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.AzureTable
{
    using System;
    using System.Reactive.Linq;

    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    /// Extension methods for the Azure Table Service.
    /// </summary>
    internal static class AzureTableServiceExtensions
    {
        /// <summary>
        /// Executes the provided <paramref name="query"/> against he provided <paramref name="table"/>, returning an
        /// <see cref="IObservable{TEntity}"/> collection of results.
        /// </summary>
        /// <param name="table">
        /// The table to execute the provided <paramref name="query"/> on.
        /// </param>
        /// <param name="query">
        /// The query to execute.
        /// </param>
        /// <typeparam name="TEntity">
        /// The table entity type.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IObservable{TEntity}"/> collection of results.
        /// </returns>
        public static IObservable<TEntity> ExecuteAsObservable<TEntity>(this CloudTable table, TableQuery<TEntity> query) where TEntity : ITableEntity, new()
        {
            return Observable.Create<TEntity>(
                async observer =>
                {
                    try
                    {
                        var segment = default(TableQuerySegment<TEntity>);
                        do
                        {
                            var continuationToken = segment == null ? null : segment.ContinuationToken;
                            segment = await table.ExecuteQuerySegmentedAsync(query, continuationToken);
                            segment.Results.ForEach(observer.OnNext);
                        }
                        while (segment.ContinuationToken != null);
                        observer.OnCompleted();
                    }
                    catch (Exception exception)
                    {
                        observer.OnError(exception);
                    }
                });
        }
    }
}
