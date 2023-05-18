using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace BlobServiceApp
{
    public class BlobHelper
    {
        private string _connectionString = "";
        public BlobServiceClient _blobServiceClient { get; set; }

        public BlobHelper(string connectionString)
        {
            _connectionString = connectionString;
            _blobServiceClient = new BlobServiceClient(_connectionString);
        }

        public void CreateContainer(string _containerName)
        {
            _blobServiceClient.CreateBlobContainer(_containerName);
        }

        public void UploadBlob(string containerName, string localFilePath)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            string fileName = Path.GetFileName(localFilePath);
            BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);

            blobClient.Upload(localFilePath, true);
        }

        public void DownloadBlob(string _containerName, string localFilePath)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            string fileName = Path.GetFileName(localFilePath);
            BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);

            blobClient.DownloadTo(localFilePath);
        }

        public void ListBlobs(string containerName, int? segmentSize)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            try
            {
                var resultSegment = blobContainerClient.GetBlobs().AsPages(default, segmentSize);

                // Enumerate the blobs returned for each page.
                foreach (Page<BlobItem> blobPage in resultSegment)
                {
                    foreach (BlobItem blobItem in blobPage.Values)
                    {
                        Console.WriteLine("Blob name: {0}", blobItem.Name);
                    }

                    Console.WriteLine();
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}
