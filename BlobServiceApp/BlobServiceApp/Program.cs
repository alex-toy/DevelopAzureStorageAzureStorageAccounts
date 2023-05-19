using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using AzureStorage;
using System;
using System.Collections.Generic;

namespace BlobServiceApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string _connectionString = "DefaultEndpointsProtocol=https;AccountName=alexeisa;AccountKey=3KVGwiblRDIrrcHPPlQAWSArcj0k9Kl9+bPv20/g5T3pcibERuY+qFNlAWMq6GyVDh77LlWv3Lu4+ASt+/9tQA==;EndpointSuffix=core.windows.net";

            var blobHelper = new BlobHelper(_connectionString);
            string containerName = "data";


            //blobHelper.CreateContainer(containerName);


            //string fileName = "C:\\source\\cSharpAzure\\DevelopAzureStorageAzureStorageAccounts\\test.png";
            //blobHelper.UploadBlob(containerName, fileName);


            //string localFilePath = "C:\\source\\cSharpAzure\\DevelopAzureStorageAzureStorageAccounts\\test.png";
            //blobHelper.DownloadBlob(containerName, localFilePath);


            //List<string> blobs = blobHelper.ListBlobs(containerName, 3);
            //foreach (string blob in blobs)
            //{
            //    Console.WriteLine($"Blob name: {blob}");
            //}


            //string localFilePath = "C:\\source\\cSharpAzure\\DevelopAzureStorageAzureStorageAccounts\\movies.csv";
            //blobHelper.DownloadBlobSas(containerName, localFilePath);


            //string blobName = "ad.png";
            //blobHelper.GetProperties(containerName, blobName);


            //string blobName = "ad.png";
            //IDictionary<string, string> metadata = blobHelper.GetMetadata(containerName, blobName);
            //foreach(var item in metadata)
            //{
            //    Console.WriteLine($"{item.Key} -> {item.Value}");
            //}


            //IDictionary<string, string> metadata = new Dictionary<string, string>()
            //{
            //    { "turnover" , "1M" },
            //    { "supply chain" , "colibri" }
            //};
            //string blobName = "ad.png";
            //blobHelper.SetMetadata(containerName, blobName, metadata);


            //string blobName = "ad.png";
            //blobHelper.GetProperties(containerName, blobName);


            string blobName = "message.txt";
            BlobLeaseClient lease = blobHelper.AcquireLease(containerName, blobName, 30, out string leaseId);
            BlobUploadOptions options = new BlobUploadOptions()
            {
                Conditions = new BlobRequestConditions()
                {
                    LeaseId = leaseId,
                }
            };
            blobHelper.UploadStringToBlob(containerName, blobName, "hello, this is the message with lease", options);
            //blobHelper.DropLease(lease);
            //blobHelper.UploadStringToBlob(containerName, blobName, "hello, this is the message without lease");



            

            //Console.ReadKey();
        }
    }
}
