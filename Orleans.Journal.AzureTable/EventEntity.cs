// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventEntity.cs" company="">
//   
// </copyright>
// <summary>
//   The event entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal.AzureTable
{
    using System.Globalization;

    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    /// The event entity.
    /// </summary>
    public class EventEntity : TableEntity, IEvent
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventEntity"/> class.
        /// </summary>
        public EventEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventEntity"/> class.
        /// </summary>
        /// <param name="partition">
        /// The partition.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        public EventEntity(string partition, ulong id)
        {
            this.PartitionKey = partition;
            this.RowKey = id.ToString("X16");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        public byte[] Event { get; set; }

        /// <summary>
        /// Gets the event id.
        /// </summary>
        [IgnoreProperty]
        public ulong EventId
        {
            get
            {
                return ulong.Parse(this.RowKey, NumberStyles.HexNumber);
            }
        }

        #endregion
    }
}