using System;
using System.IO;

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


            //string fileName = "C:\\source\\cSharpAzure\\DevelopAzureStorageAzureStorageAccounts\\ad.png";
            //blobHelper.UploadBlob(containerName, fileName);


            //string localFilePath = "C:\\source\\cSharpAzure\\DevelopAzureStorageAzureStorageAccounts\\test.png";
            //blobHelper.DownloadBlob(containerName, localFilePath);


            blobHelper.ListBlobs(containerName, 3);


            Console.ReadKey();
        }
    }
}
