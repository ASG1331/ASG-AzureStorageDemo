using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace AzureStrorageAcctApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reference to the ConnectionString in the App.Config file    
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnection"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("images");
            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);



            //To download image from BLOB to system
            CloudBlockBlob blockBlob2 = container.GetBlockBlobReference("Rose.jpg");


            using (var fileStream = System.IO.File.OpenWrite(@"D:\Arati\Rose.jpg"))
            {
                blockBlob2.DownloadToStream(fileStream);
            }


            ///To upload image from system to BLOB
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("PinkRose.jpg");


            using (var fileStream = System.IO.File.OpenRead(@"D:\Arati\PinkRose.jpg"))
            {
                blockBlob.UploadFromStream(fileStream);
            }






            Console.ReadKey();

        }
    }
}
