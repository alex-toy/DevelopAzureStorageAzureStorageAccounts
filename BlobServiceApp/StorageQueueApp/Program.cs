using AzureStorage;
using System;

namespace StorageQueueApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=alexeisa;AccountKey=3KVGwiblRDIrrcHPPlQAWSArcj0k9Kl9+bPv20/g5T3pcibERuY+qFNlAWMq6GyVDh77LlWv3Lu4+ASt+/9tQA==;EndpointSuffix=core.windows.net";
            string queueName = "appqueue2";
            QueueHelper queue = new QueueHelper(connectionString, queueName);

            queue.CreateQueue();

            //for(int i = 0; i < 5; i++) queue.SendMessage($"message {i}");
        }
    }
}
