using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace manageazurequeue
{    
    public class QueueManager
    {
        // Connection string of the storage account where the queue is located
        string connectionString = "<CONNECTION STRING>";

        // Name of the queue
        string queueName = "<QUEUE NAME>";
        
        public void InsertMessage(string message, int count)
        {           
            // Create Queue Client for interaction with Storage Accounts queues
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queueName);
            CloudQueueMessage messageToBeAdded = new CloudQueueMessage($"{message}");

            // Send amount of messages corresponding with provided "count"
            for (int i = 0; i < count; i++){  
            queue.AddMessage(messageToBeAdded); 
            var time = DateTime.Now;
            Console.WriteLine($"[{time.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")}]: Message {i +1} added to queue \"{queueName}\""); 
            }
        }
    }
}