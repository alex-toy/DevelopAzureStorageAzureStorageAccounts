using Microsoft.Azure.Cosmos.Table;

namespace AzureStorage
{
    public class TableStorageHelper
    {
        private readonly string _connectionString;
        public CloudStorageAccount _storageAccount { get; set; }

        public TableStorageHelper(string connectionString)
        {
            _connectionString = connectionString;
            _storageAccount = CloudStorageAccount.Parse(_connectionString);
        }

        public void CreateTable(string tableName)
        {
            CloudTable table = GetTable(tableName);
            table.CreateIfNotExists();
        }

        private CloudTable GetTable(string tableName)
        {
            CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);
            return table;
        }

        public void AddEntity(string tableName, TableEntity entity)
        {
            TableOperation operation = TableOperation.Insert(entity);
            CloudTable table = GetTable(tableName);
            TableResult result = table.Execute(operation);
        }
    }
}
