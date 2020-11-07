using System;
using System.IO;
using System.Text;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace QueueProcessorDocker
{
    public static class QueueProcessor
    {
        [FunctionName("QueueProcessor")]
        public static void Run([QueueTrigger("<QUEUE NAME>", Connection = "storageAccountConnectionString")]string myQueueItem, ILogger log)
        {

            // Connection string for the Storage Account that we use to store the files 
            string connectionString = Environment.GetEnvironmentVariable("storageAccountConnectionString");
            string storageContainerName = Environment.GetEnvironmentVariable("storageContainerName");

            log.LogInformation($"Processing item: {myQueueItem}");
            
            // Create the blob client
            var blobServiceClient = new BlobServiceClient(connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(storageContainerName);

            // Create the container if it doesn't exist (this means you can throw it away after your test :) )
            blobContainerClient.CreateIfNotExists();
            var blobName = Guid.NewGuid().ToString() + ".txt";

            // Create a stream from the queue item and store it in the blob container (as txt))
            byte[] byteArray = Encoding.UTF8.GetBytes(myQueueItem);
            MemoryStream stream = new MemoryStream(byteArray);

            blobContainerClient.UploadBlob(blobName, stream);

        }
    }
}
