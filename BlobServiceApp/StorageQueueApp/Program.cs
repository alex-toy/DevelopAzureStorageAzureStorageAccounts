using Azure.Storage.Queues.Models;
using AzureStorage;
using System;

namespace StorageQueueApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=alexeisa;AccountKey=3KVGwiblRDIrrcHPPlQAWSArcj0k9Kl9+bPv20/g5T3pcibERuY+qFNlAWMq6GyVDh77LlWv3Lu4+ASt+/9tQA==;EndpointSuffix=core.windows.net";
            string queueName = "appqueue";
            QueueHelper queue = new QueueHelper(connectionString, queueName);

            //queue.CreateQueue();

            //for(int i = 0; i < 5; i++) queue.SendMessage($"message {i}");

            //PeekedMessage[] messages = queue.PeekMessages(3);
            //foreach (var message in messages)
            //{
            //    Console.WriteLine($"{message.MessageId} - {message.InsertedOn} - {message.Body.ToString()}");
            //}

            QueueMessage message = queue.ReceiveMessage();
            Console.WriteLine($"{message.MessageId} - {message.InsertedOn} - {message.Body.ToString()}");

        }
    }
}
