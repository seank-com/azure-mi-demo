using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.Threading.Tasks;

namespace AzureMIBlobDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Beginning container creation in Azure Blob Storage...");

            string blobServiceEndpoint = "https://midemosa.blob.core.windows.net/";
            var credential = new DefaultAzureCredential();
            var blobServiceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), credential);

            await CreateContainerAsync(blobServiceClient, "mycontainer");

            Console.WriteLine("Container creation in Azure Blob Storage complete!");
        }

        private static async Task CreateContainerAsync(BlobServiceClient blobServiceClient, string containerName)
        {
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync();
            Console.WriteLine($"Container '{containerName}' created or already exists.");
        }
    }
}
