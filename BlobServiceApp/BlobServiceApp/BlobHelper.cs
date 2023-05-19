using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.IO;

namespace BlobServiceApp
{
    public class BlobHelper
    {
        private string _connectionString = "";
        public BlobServiceClient _storageAccount { get; set; }

        public BlobHelper(string connectionString)
        {
            _connectionString = connectionString;
            _storageAccount = new BlobServiceClient(_connectionString);
        }

        public void CreateContainer(string _containerName)
        {
            _storageAccount.CreateBlobContainer(_containerName);
        }

        public void UploadBlob(string containerName, string localFilePath)
        {
            string fileName = Path.GetFileName(localFilePath);
            BlobClient blobClient = GetBlobClient(containerName, fileName);
            blobClient.Upload(localFilePath, true);
        }

        public void DownloadBlob(string containerName, string localFilePath)
        {
            string fileName = Path.GetFileName(localFilePath);
            BlobClient blobClient = GetBlobClient(containerName, fileName);
            blobClient.DownloadTo(localFilePath);
        }

        public BlobProperties GetProperties(string containerName, string blobName)
        {
            BlobClient blobClient = GetBlobClient(containerName, blobName);

            BlobProperties properties = blobClient.GetProperties().Value;
            return properties;
        }

        public IDictionary<string, string> GetMetadata(string containerName, string blobName)
        {
            BlobProperties properties = GetProperties(containerName, blobName);
            IDictionary<string, string> metadata = properties.Metadata;
            return metadata;
        }

        public List<string> ListBlobs(string containerName, int? segmentSize)
        {
            List<string> blobs = new List<string>();
            BlobContainerClient container = _storageAccount.GetBlobContainerClient(containerName);
            try
            {
                var resultSegment = container.GetBlobs().AsPages(default, segmentSize);

                foreach (Page<BlobItem> blobPage in resultSegment)
                {
                    foreach (BlobItem blobItem in blobPage.Values)
                    {
                        blobs.Add(blobItem.Name);
                    }
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return blobs;
        }

        public void DownloadBlobSas(string containerName, string localFilePath)
        {
            BlobContainerClient container = _storageAccount.GetBlobContainerClient(containerName);

            string fileName = Path.GetFileName(localFilePath);
            BlobClient blobClient = container.GetBlobClient(fileName);

            Uri blobUri = GenerateSAS(blobClient, containerName, fileName);

            BlobClient blobClient1 = new BlobClient(blobUri);
            blobClient1.DownloadTo(localFilePath);
        }

        private Uri GenerateSAS(BlobClient blobClient, string containerName, string fileName)
        {
            BlobSasBuilder builder = new BlobSasBuilder()
            {
                BlobContainerName = containerName,
                BlobName = fileName,
                Resource = "b"
            };

            builder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);
            builder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);

            return blobClient.GenerateSasUri(builder);
        }

        private BlobClient GetBlobClient(string containerName, string blobName)
        {
            BlobContainerClient container = _storageAccount.GetBlobContainerClient(containerName);
            BlobClient blobClient = container.GetBlobClient(blobName);
            return blobClient;
        }
    }
}
