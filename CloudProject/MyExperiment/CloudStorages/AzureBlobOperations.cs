using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using MyCloudProject.Common;
using MyExperiment.Exceptions;
using MyExperiment.Utilities;


namespace MyExperiment.CloudStorages
{
    public class AzureBlobOperations : IStorageProvider
    {
        private MyConfig config;

        /// <summary>
        /// Represents constructor
        /// </summary>
        /// 
        /// <param name="configSection"> configuration object </param>
        public AzureBlobOperations(IConfigurationSection configSection)
        {
            config = new MyConfig();
            configSection.Bind(config);
        }

        /// <summary>
        ///  Downloads file from the azure container blob
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> DownloadInputFile(string fileName)
        {
            if (StringUtilities.isBlankOrNull(fileName))
            {
                throw new EmptyStringException("File name cannot be empty or null");
            }

            string localStorageFilePath = Path.Combine(Experiment.DataFolder, new FileInfo(fileName).Name);
            Microsoft.Azure.Storage.CloudStorageAccount cloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount.Parse(config.StorageConnectionString);
            var blob = new CloudBlockBlob(new Uri(fileName), cloudStorageAccount.Credentials);
            await blob.DownloadToFileAsync(localStorageFilePath, FileMode.Create);
            return localStorageFilePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task UploadExperimentResult(ExperimentResult result)
        {
            if (result == null)
            {
                throw new ObjectShouldNotBeNUllException("Result object cannot be null");
            }

            CloudTable table =
                await AzureTableOperations.CreateTableAsync(config.ResultTable,
                    config.StorageConnectionStringCosmosTable);
            await AzureTableOperations.InsertOrMergeEntityAsync(table, result);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
      public async Task<byte[]> UploadResultFile(string fileName, byte[] data)
       
        {

            if (StringUtilities.isBlankOrNull(fileName))
            {
                throw new EmptyStringException("File name cannot be empty or null");
            }
            // Creates a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(config.StorageConnectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(config.ResultContainer);
          
            // Create a local file in the ./data/ directory for uploading and downloading
            
            string localFilePath = Path.Combine(Experiment.DataFolder, fileName);

            // Write text to the file 
            // Adding a check to write a data in a file only if data is not equal to null
            // This is important as we need to re-use this method to upload a file in which data has already been written
            if (data != null)
            {
                File.WriteAllBytes(localFilePath, data);
               
            }

            // Get a reference to a blob

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            // Open the file and upload its data
            
             using FileStream uploadFileStream = File.OpenRead(localFilePath);

               await blobClient.UploadAsync(uploadFileStream, true);

               uploadFileStream.Close();

               return Encoding.ASCII.GetBytes(blobClient.Uri.ToString());
            
            
        }
        /*Seperate  Function to Download output file from Blob storage without the need of any seperate Queue Trigger*/
        /*Used in order to feed the Serialized Output subsequently to the Deserializer and validate accuracy of Cloud Operation*/
        public async Task download_from_blob()
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
           
            string containerName = "result-files";
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            
            Console.WriteLine("Listing blobs...");

            string localPath = @".\downloadlocation\";

            string fileName = "SPOutput1.zip";

            string localFilePath = Path.Combine(localPath,fileName);

            // Get a reference to a blob

            BlobClient blobClient = containerClient.GetBlobClient("SPOutput1.zip");

       
           // Download the blob's contents and save it to a file

            BlobDownloadInfo download = await blobClient.DownloadAsync();

            using (FileStream downloadFileStream = File.OpenWrite(localFilePath))
            {
                await download.Content.CopyToAsync(downloadFileStream);

                downloadFileStream.Close();
            }
        }
       

    }
}
