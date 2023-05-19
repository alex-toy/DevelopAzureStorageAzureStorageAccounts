using Microsoft.Azure.Cosmos.Table;

namespace TableStorageApp.Entities
{
    public class Customer : TableEntity
    {
        public string Name { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string city, string customerId)
        {
            Name = name;
            PartitionKey = city;
            RowKey = customerId;
        }
    }
}
