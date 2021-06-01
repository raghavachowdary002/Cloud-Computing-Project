using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCloudProject.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyExperiment.Models;
using MyExperiment.Utilities;
using MyExperiment.CloudStorages;
using MyExperiment.SEProjectCode;
using UnitTestsProject;
using Ionic.Zip;
using System.Linq;
using System.IO.Compression;

namespace MyExperiment
{
    public class Experiment : IExperiment
    {
        public static string DataFolder { get; private set; }
        private IStorageProvider storageProvider;
        private ILogger logger;
        private MyConfig config;

        /// <summary>
        /// Constructor configuration
        /// </summary>
        /// <param name="configSection"></param>
        /// <param name="storageProvider"></param>
        /// <param name="log"></param>

        public Experiment(IConfigurationSection configSection, IStorageProvider storageProvider, ILogger log)
        {
            this.storageProvider = storageProvider;
            this.logger = log;

            config = new MyConfig();
            configSection.Bind(config);
            
        /*  Creating the directory where Input file downloaded from Blob will be stored and output of Test file will be stored locally*/ 

            DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                config.LocalPath);
            Directory.CreateDirectory(DataFolder);
                   }

        /// <summary>
        /// Runs the project via data locally and update record of results received in addition
        /// to time stamps and duration 
        /// </summary>
        /// <param name="localFileName"></param>
        /// <returns></returns>
        public async Task<ExperimentResult> Run(string localFileName)
        {

            var seProjectInputDataList =
                JsonConvert.DeserializeObject<SeProjectInputDataModel>(FileUtilities.ReadFile(localFileName));

            var startTime = DateTime.UtcNow;

            // running until the input ends
            string uploadedDataURI = await RunSoftwareEngineeringExperiment(seProjectInputDataList);

            // Added delay
            Thread.Sleep(5000);
            var endTime = DateTime.UtcNow;
            logger?.LogInformation(
                $"Ran all test cases as per input from the blob storage");

            long duration = endTime.Subtract(startTime).Seconds;

            var res = new ExperimentResult(this.config.GroupId, Guid.NewGuid().ToString());
            UpdateExperimentResult(res, startTime, endTime, duration, localFileName, uploadedDataURI);
            return res;
        }

        /// <inheritdoc/>

        public async Task RunQueueListener(CancellationToken cancelToken)
        {
            CloudQueue queue = await AzureQueueOperations.CreateQueueAsync(config, logger);

            while (cancelToken.IsCancellationRequested == false)
            {
                var message = await queue.GetMessageAsync(cancelToken);
                try
                {
                    if (message != null)
                    {
                        // STEP 1. Reading message from Queue and deserializing

                        var experimentRequestMessage =
                            JsonConvert.DeserializeObject<ExerimentRequestMessage>(message.AsString);
                        logger?.LogInformation(
                            $"Received message from the queue with experimentID: " +
                            $"{experimentRequestMessage.ExperimentId}, " +
                            $"description: {experimentRequestMessage.Description}, " +
                            $"name: {experimentRequestMessage.Name}");

                        // STEP 2. Downloading the input file from the blob storage
                        var fileToDownload = experimentRequestMessage.InputFile;
                        var localStorageFilePath = await storageProvider.DownloadInputFile(fileToDownload);

                        logger?.LogInformation(
                            $"File download successful. Downloaded file link: {localStorageFilePath}");


                        // STEP 3. Running SE experiment with inputs from the input file
                        var result = await Run(localStorageFilePath);
                        result.Description = experimentRequestMessage.Description;
                       var resultAsByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result));
                    

                        // STEP 4. Uploading result file to blob storage
                          var uploadedUri =
                              await storageProvider.UploadResultFile("ResultFile-" + Guid.NewGuid() + ".txt",
                                  resultAsByte);
                       
                        logger?.LogInformation($"Uploaded result file on blob");
                          result.SeExperimentOutputBlobUrl = Encoding.ASCII.GetString(uploadedUri);
                        
                        // STEP 5. Uploading result file to table storage
                        await storageProvider.UploadExperimentResult(result);



                        // STEP 6. Deleting the message from the queue
                      await queue.DeleteMessageAsync(message, cancelToken);

                       
                    }

                }
                //this.logger?.LogInformation($"Received the message {message.AsString}");
                catch (Exception ex)
                {
                    logger?.LogError(ex, "Caught an exception: {0}", ex.Message);
                  await queue.DeleteMessageAsync(message, cancelToken);
                }

                // pause
                await Task.Delay(500, cancelToken);
                

            }
       


                        this.logger?.LogInformation("Cancel pressed. Exiting the listener loop.");
        }

        /// <summary>
        /// Updating the experiment result record 
        /// </summary>
        /// <param name="experimentResult"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="duration"></param>
        /// <param name="downloadFileUrl"></param>
        /// <param name="testCaseOutputUri"></param>
        private static void UpdateExperimentResult(ExperimentResult experimentResult, DateTime startTime,
            DateTime endTime, long duration, string downloadFileUrl, string testCaseOutputUri)
        {
            experimentResult.StartTimeUtc = startTime;
            experimentResult.EndTimeUtc = endTime;
            experimentResult.DurationSec = duration;
            experimentResult.Name = "SpatialPoolerSerialization";
            experimentResult.InputFileUrl = downloadFileUrl;
            experimentResult.SeExperimentOutputFileUrl = testCaseOutputUri;
        }

        /// <summary>
        /// Runs the experiment and uploads the results on blob storage
        /// </summary>
        /// <param name="seProjectInputDataList"></param>
        /// <returns></returns>
        private async Task<string> RunSoftwareEngineeringExperiment(
            SeProjectInputDataModel seProjectInputDataList)
        {
           
            //Step1: Implementation and reference of our Unittests

            var inputVector = seProjectInputDataList.inputData;

            SpatialPoolerSerializeTestCloud serializetest = new SpatialPoolerSerializeTestCloud();

            var output = serializetest.SerializationTestWithTrainedData(inputVector);

            /*Writing Output data to the specific file*/

            FileUtilities.WriteDataInFile("SpatialPoolerSerializationOutput.txt", inputVector,
                output);
            //Adding delay 

            Thread.Sleep(4000);

            /*Compressing the output file for Blob Upload*/

            string myString = Experiment.DataFolder + "SPOutput1.zip";

            string anotherString = Experiment.DataFolder + "SpatialPoolerSerializationOutput.txt";
          
            using (FileStream fs = new FileStream(myString, FileMode.Create))

            using (ZipArchive arch = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                
                arch.CreateEntryFromFile(anotherString, "SpatialPoolerSerializationOutput.txt");
            }
            var uploadedUri =
                await storageProvider.UploadResultFile("SPOutput1.zip",
                    null);


            logger?.LogInformation(
                $"Test cases output file uploaded successful. Blob URL: {Encoding.ASCII.GetString(uploadedUri)}");

            Thread.Sleep(30000);
          
          //  logger?.LogInformation(
          //      $"Test cases output file uploaded successful. Blob URL: {uploadedUri}");

           //Step 2: Downloading the Serialized Output from the Blob Storage to test if it works with Deserializer subsequently//
            
            await storageProvider.download_from_blob();

            // STEP 3.Extracting the Downloadeded Files 
            
            var extractPath = @".\";

            string zipPath = @".\downloadlocation\SPOutput1.zip";

            ExtractFromBlob newExtract = new ExtractFromBlob();

            newExtract.ExtractMethod(zipPath, extractPath);


            // STEP 4. Running SE experiment with inputs from the Downloaded and Extracted Blob file
            Thread.Sleep(20000);

            SpatialPoolerSerializeTestCloud spDeserializer = new SpatialPoolerSerializeTestCloud();
            
            var sp=spDeserializer.SpatialPoolerCloudDeserializerTest("SpatialPoolerSerializationOutput.txt");

            

            
             sp.Serializer("LocalSerializedFile.txt");

            string des1 = File.ReadAllText("LocalSerializedFile.txt");

            int comp = string.Compare(output, des1);
            if(comp==0)
            {
                Console.WriteLine("Spatial Pooler Object deserialized");
            }
            else
            {
                Console.WriteLine("Not all the properties are serialized/deserialized properly");
            }
            
            // return a string and delete the combined file if possible

            return "Project completed";
        }

        

   
    }
}