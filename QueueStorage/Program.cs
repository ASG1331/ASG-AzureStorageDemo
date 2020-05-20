using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
namespace AzureQueueStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reference to the ConnectionString in the App.Config file  
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnection"));
            CloudQueueClient QueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = QueueClient.GetQueueReference("tasks");
            queue.CreateIfNotExists();

            //for writing
            TimeSpan expTime = new TimeSpan(24, 0, 0);
            CloudQueueMessage message = new CloudQueueMessage("Task 2");
            queue.AddMessage(message, expTime, null, null);
            Console.WriteLine("Message Inserted");

            //Peek at the next message-Retriving data
            CloudQueueMessage peekedMessage = queue.PeekMessage();
            // Display message. 
            Console.WriteLine(peekedMessage.AsString);

            Console.ReadKey();
        }
    }
}
