using AzureStorage;
using System;
using System.Collections.Generic;
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


            //Customer customer = new Customer("jérémie", "genève", "C4");
            //tableStorage.AddEntity(tableName, customer);


            //List<Customer> customers = new List<Customer>
            //{
            //    new Customer("alex", "paris", "C5"),
            //    new Customer("seb", "paris", "C6"),
            //    new Customer("kate", "paris", "C7"),
            //};
            //tableStorage.AddEntities(tableName, customers);


            //Customer customer = tableStorage.GetEntity<Customer>(tableName, "lyon", "C2");
            //Console.WriteLine($"The client with customerId {customer.RowKey} is called {customer.Name}");


            //Customer customer = new Customer("mathieux", "genève", "C4");
            //tableStorage.UpdateEntity<Customer>(tableName, customer);


            Customer customer = tableStorage.GetEntity<Customer>(tableName, "lyon", "C2");
            tableStorage.DeleteEntity<Customer>(tableName, customer);
        }
    }
}
