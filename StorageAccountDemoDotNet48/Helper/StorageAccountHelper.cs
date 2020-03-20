using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccountDemoDotNet48.Helper
{
    public class StorageAccountHelper : IStorageAccountHelper
    {
        private BlobContainerClient GetBlobContainerClient()
        {
            // Get a credential and create a client object for the blob container.
            return new BlobContainerClient(new Uri(string.Format("https://{0}.blob.core.windows.net/{1}",
                                                   ConfigurationManager.AppSettings["accountName"],
                                                      ConfigurationManager.AppSettings["containerName"])),
                                                                              new DefaultAzureCredential());
        }
        public async Task CreateBlockBlobAsync(string blobName)
        {
            // Get a credential and create a client object for the blob container.
            BlobContainerClient containerClient = GetBlobContainerClient();

            try
            {
                // Create the container if it does not exist.
                await containerClient.CreateIfNotExistsAsync();

                // Upload text to a new block blob.
                string blobContents = "This is a block blob.";
                byte[] byteArray = Encoding.ASCII.GetBytes(blobContents);

                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    await containerClient.UploadBlobAsync(blobName, stream);
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
        public async Task<string> DownloadBlockBlobAsync(string blobName)
        {
            // Get a credential and create a client object for the blob container.
            BlobContainerClient containerClient = GetBlobContainerClient();
            BlobClient blob = containerClient.GetBlobClient(blobName);

            // Download the blob
            var download = await blob.DownloadAsync();

            // convert stream to string
            using (var reader = new StreamReader(download.Value.Content))
                return reader.ReadToEnd();
        }
    }
}