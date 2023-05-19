using Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;

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

        public void AddEntity<T>(string tableName, T entity) where T : TableEntity
        {
            TableOperation operation = TableOperation.Insert(entity);
            CloudTable table = GetTable(tableName);
            TableResult result = table.Execute(operation);
        }

        public void AddEntities<T>(string tableName, IEnumerable<T> entities) where T : TableEntity
        {
            TableBatchOperation operation = new TableBatchOperation();
            foreach(var entity in entities) operation.Insert(entity);

            CloudTable table = GetTable(tableName);
            TableBatchResult result = table.ExecuteBatch(operation);
        }

        public T GetEntity<T>(string tableName, string partitionKey, string rowKey) where T : TableEntity
        {
            TableOperation operation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            CloudTable table = GetTable(tableName);
            TableResult result = table.Execute(operation);
            return result.Result as T;
        }

        public void UpdateEntity<T>(string tableName, T entity) where T : TableEntity
        {
            TableOperation operation = TableOperation.InsertOrMerge(entity);
            CloudTable table = GetTable(tableName);
            TableResult result = table.Execute(operation);
        }

        public void DeleteEntity<T>(string tableName, T entity) where T : TableEntity
        {
            TableOperation operation = TableOperation.Delete(entity);
            CloudTable table = GetTable(tableName);
            TableResult result = table.Execute(operation);
        }
    }
}
