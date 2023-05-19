using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorage
{
    public class QueueHelper
    {
        private readonly string _connectionString;
        private readonly string _queueName;
        public QueueClient _queue { get; set; }

        public QueueHelper(string connectionString, string queueName)
        {
            _connectionString = connectionString;
            _queueName = queueName;
            _queue = new QueueClient(_connectionString, _queueName);
        }
    }
}
