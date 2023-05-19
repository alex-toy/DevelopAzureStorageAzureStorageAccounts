using AzureStorage;
using System;
using TableStorageApp.Entities;

namespace TableStorageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=alexeisa;AccountKey=3KVGwiblRDIrrcHPPlQAWSArcj0k9Kl9+bPv20/g5T3pcibERuY+qFNlAWMq6GyVDh77LlWv3Lu4+ASt+/9tQA==;EndpointSuffix=core.windows.net";
            TableStorageHelper tableStorage = new TableStorageHelper(connectionString);

            string tableName = "Sales";


            //tableStorage.CreateTable(tableName);


            Customer customer = new Customer("alex", "lyon", "C1");
            tableStorage.AddEntity(tableName, customer);
        }
    }
}
