using System;
using AzureFunctionStorageQueue.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace AzureFunctionStorageQueue
{
    public class QueueMessage
    {
        [FunctionName("GetMessages")]
        [return: Table("Orders", Connection = "storage-connection-string")]
        public Order Run([QueueTrigger("appqueue", Connection = "storage-connection-string")]JObject queueOrder, ILogger log)
        {

            Order _order = new Order()
            {
                PartitionKey = queueOrder["Category"].ToString(),
                RowKey = queueOrder["OrderID"].ToString(),
                Quantity = Convert.ToInt32(queueOrder["Quantity"]),
                UnitPrice = Convert.ToDecimal(queueOrder["UnitPrice"])
            };

            log.LogInformation($"Order written to table : {queueOrder}");

            return _order;
        }
    }
}
