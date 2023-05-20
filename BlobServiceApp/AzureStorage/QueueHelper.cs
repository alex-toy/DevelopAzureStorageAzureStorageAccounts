using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
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

        public void CreateQueue()
        {
            _queue.CreateIfNotExists();
        }

        public void SendMessage(string message)
        {
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            string messageBase64 = System.Convert.ToBase64String(messageBytes);
            _queue.SendMessage(messageBase64);
        }

        public PeekedMessage[] PeekMessages(int nbOfMessages = 1)
        {
            PeekedMessage[] messages = _queue.PeekMessages(nbOfMessages);
            return messages;
        }

        public QueueMessage ReceiveMessage()
        {
            QueueMessage message = _queue.ReceiveMessage();
            return message;
        }
    }
}
