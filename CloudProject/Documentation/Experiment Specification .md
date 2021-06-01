
## Experiment Description
## Software Engineering Project review 
Spatial Pooler is an algorithm of Hierarchical Temporal Memory.The SP takes a binary input and produces a new Sparse Distributed Representation (SDR) of the input, here an SDR is a binary vector typically having a sparse number of active bits, i.e., a bit with a value of “1”. Hence SP works as a mapping function that transforms input domain to a feature domain. The mapped output from Spatial Pooler in the form of SDR Data is then subsequently fed to Temporal Memory.
Serialization is the process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed. In our Software Engineering Project, Serialization of the Spatial Pooler model was implemented in .NET environment. The serialization technique was integrated to the existing HTM model. 
Subsequently the model was tested in the following way. An Input Vector of given dimesion was applied to a Spatial Pooler Object. The model was trained with some iterations and the result was serialized with the newly implemnted Serializer method of Spatial Pooler. The serialized properties of the particular Spatial Pooler was stored in a file. Next, the file was again used in Spatial Pooler Deserialization Method and the exact same instance of Spatial Pooler (which was used earlier) could be recreated.

URL to the SE Project Documentation for reference : https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2019-2020/tree/GroupSW/Source/HTM/UnitTestsProject/Spatial%20Pooler%20Serialization%20Documentation%20Group%20SW/Serialization%20of%20Spatial%20Pooler%20Group%20SW.pdf

## Cloud Computing Project
From the general context, using a cloud based software comes on with many advantages; some of that being cost-saving, improved collaboration,better scalability, mobility, flexibility, efficient resource allocation etc. In view of this particular Software Engineering project Serialization of Spatial Pooler, it can be particularly highlighted that using Cloud Service to deploy the project would enhance mobility and flexibility.
The Serialized properties of an instance of Spatial Pooler, especially with Trained Model, contains a lot of data. If this Software is deployed in Cloud then the benefit of Azure Storage can be leveraged by storing Serialized Properties of any number of instances of Spatial Pooler and subsequently the same storage can be used to recreate Spatial Pooler object with the deserialization function anywhere and anytime. Thus, it will save significant amount of computing and storage resources of the local environment. 
The general architecture of the Cloud Computing Project is as per the following workflow :


1.Upload the Input File to blob storage
2.Send a Trigger message in Queue
3.Perform Deserialization
4.Download input file from blob storage
5.Run the testcases of Serialization of Spatial Pooler
6.Download first output file from blob storage
7.Use the downloaded file in Spatial Pooler Deserialization function
8.Upload Result/Output file to table and blob storage
9.Delete message from Queue

## Code Overview
The entire projects are contained in the MyCloudProject solution. The focal point of this project according to the workflow described above is Experiment.cs class. It is located in the MyExperiment directory in the project folder and this is called by the main Program.cs class for execution. 
The aim of the experiment class is to locally create the folder path where files will be downloaded from blob storage and executed and uploaded back to azure (Blob & Table). Subsequently the uploaded Blob will again be downloaded, extracted, and fed to test the accuracy of the deserialization method of Spatial Pooler and thus would demonstrate the advantages of the Cloud Computing functionalities specific to this project. The program will then be executed via a cancelation token until it is signalled to cancel. The program's outcomes are then uploaded to the storage blob and table.

## Input
In our experiment input is a 16x16 Array consisting of sequence 1 and 0. This input qualifies as the inputVector parameter for a Spatial Pooler of dimension 32x32.
~~~json
{	  "inputData": [	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	0	  ]		}
~~~

## Queue Message
~~~
{
     "ExperimentId" : "ML 19/20 - 5.8",
     "InputFile" : "https://aniklogu.blob.core.windows.net/anikblobcontainer/InputData.json", 
     "Name" : "Testing input1.json",
     "Description" : "project review"
 }
 ~~~
## Azure Cloud Settings

### "appsettings.json"

~~~json
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },

  "MyConfig": {
    "GroupId": "GroupSW",
    "StorageConnectionString": "DefaultEndpointsProtocol=https;AccountName=aniklogu;AccountKey=SeLCYE8dXWhnKUKihoW0sof8NK8GsvYxWxbMcNKjmihGO1S0ijqaIFajwu44pWMZctViekkt1Y0zGFf/plNCRQ==;EndpointSuffix=core.windows.net",
    "TrainingContainer": "training-files",
    "ResultContainer": "result-files",
    "ResultTable": "results",
    "Queue": "trigger-queue",
    "StorageConnectionStringCosmosTable": "DefaultEndpointsProtocol=https;AccountName=aniklogucdb;AccountKey=x3H4dWs8iKeAZVW40qtPE6yR6vaCwgwrwFR4vaISfvzafxVbbGjHJX2tfrbtpMhAf0E9Cjv1SFpXJFRrWdrnIw==;TableEndpoint=https://aniklogucdb.table.cosmos.azure.com:443/;",
    "LocalPath": "./data/"
  }
~~~


## How to run experiment
Step 1 : Create two Blob Containers for input file and result file with appropriate names. Upload the follwoing JSON file to the container for input files.
## Input

~~~json
{	  "inputData": [	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    1,	    0,	    0,	    0,	    0,	    0,	    0,	    0,	0	  ]		}
~~~
Step 2: Update the appsettings.json file with appropriate "StorageConnectionString" and "StorageConnectionStringCosmosTable" with respect to the Blob Storage and CosmosDB storage to be used.

Step 3: Save the AZURE connection settings in the local system as an environment variable.This step is only required to verify the Spatial Pooler Deserialization functionality. Following are the ways to do the same in different OS.

Windows :
~~~
setx AZURE_STORAGE_CONNECTION_STRING "StorageConnectionString"
~~~
Linux:
~~~
export AZURE_STORAGE_CONNECTION_STRING ="StorageConnectionString"
~~~
macOS:
~~~
export AZURE_STORAGE_CONNECTION_STRING="StorageConnectionString"
~~~

Step 4: Start the experiment. A queue with the name triggered queue would be created in the Azure Portal/Queue Storage. Add the following message to the queue.
Before adding the queue, update the InputFile URL in this message as per the one with the Input file in Blob storage.
## Queue Message
~~~
{
     "ExperimentId" : "ML 19/20 - 5.8",
     "InputFile" : "https://aniklogu.blob.core.windows.net/anikblobcontainer/InputData.json", 
     "Name" : "Testing input1.json",
     "Description" : "project review"
 }
 ~~~
 Step 5: The experiment would continue with the following sequence : downloading the input file from Blob Storage, running the Software Engineering experiment(Serialize the trained Spatial Pooler model), uploading the output to Blob storage, downloading the output again from Blob storage and use it in Spatial Pooler deserializer function, carrying out deserialization to Spatial Pooler object; and finally uploading result files to Table storage.

 IMPORTANT NOTE: There may occur an error in the first attempt while running the process with the message "Cannot access the file".In this case please stop the process and run it once again.It should resolve the issue.
 If the process needs to be run multiple times (3 or more times), please make sure to delete the files "SpatialPoolerSerializationOutput.txt" and "SPOutput1.zip" from the local folder after each successfull execution of the experiment. The reason is that multiple execution of the process will write the Serialized properties to the Local files multiple times and this will cause error while trying to deserialize from the same file.   

### Result
The output of the Experiment is uploaded as result-files to Azure Blob and Table storage. The parameters declared in ExperimentResult.cs class for example TimeStamp,OutputURL etc can be validated in the Table Storage. 





