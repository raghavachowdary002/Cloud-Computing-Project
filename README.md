# Cloud-Computing-Project
This Project was to deploy already developed project called Serialization of Spatial Pooler on Microsoft Azure Cloud. The Serialization of Spatial Pooler project was to integrate feasible serialization technique in Spatial pooler module in .NET environment.

# Overview of Serialization of Spatial Pooler
Hierarchical temporal memory (HTM), inspired by the architecture and functionality of Neocortex, is designed to learn sequences and make predictions. Vast amount of information is fed to our brain through our sensory systems which remodels raw external data from light, sound pressure, skin deformations etc. In order to organize these data and constitute our  perceptibility cortical neurons forms synaptic connections to a subset of the presynaptic neurons. This learning mechanism by cortical neurons to specific input patterns and collective input specific representation of a population of neurons inspires the algorithmic property of Hierarchical temporal memory. Two primary algorithms of the current version of HTM are Spatial Pooler (SP) and Temporal Memory (TM). The SP takes a binary input and produces a new Sparse Distributed Representation (SDR) of the input, here an SDR is a binary vector typically having a sparse number of active bits, i.e., a bit with a value of “1”. Hence SP works as a mapping function that transforms input domain to a feature domain. The mapped output from Spatial Pooler in the form of SDR Data is then subsequently fed to Temporal Memory.  Serialization is the process of converting an object 
into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed. The HTM Spatial Pooler software model incorporates complex data handling constituted by different type of properties. In the previously implemented Software Engineering Project, JSON serialization technique was used to serialize and deserialize the properties of Spatial Pooler object. Special calibrations were done in JSON serializer settings to handle complex type serialization. Member Serialization attributes had to be used in Spatial Pooler class and its constituent property class Connections. The serialization model was successfully tested to store all the properties of a trained Spatial Pooler object model into a file (of JSON,.txt or relevant extensions) and subsequently was capable of recreating the same Spatial Pooler object from that file through the deserialization model.

# Significance of Implementing the Software Engineering project in Cloud Technology 
From the general context, using a cloud based software comes on with many advantages; some of that being cost-saving, improved collaboration,better scalability, mobility, flexibility, efficient resource allocation etc. In view of this particular Software Engineering project Serialization of Spatial Pooler, it can be particularly highlighted that using Cloud Service to deploy the project would enhance mobility and flexibility. The Serialized properties of an instance of Spatial Pooler, especially with Trained Model, contains a lot of data. If this Software is deployed in Cloud then the benefit of Azure Storage can be leveraged by storing Serialized Properties of any number of instances of Spatial Pooler and subsequently the same storage can be used to recreate Spatial Pooler object with the deserialization function anywhere and anytime. Thus, it will save significant amount of computing and storage resources of the local environment

# Project's Workflow

  ![image-004](https://user-images.githubusercontent.com/84661500/120311938-677e7f80-c2d8-11eb-82e2-cf942974b7dc.png)
 
**Develop the code as an Azure Function and publish it as a Docker Container:** At First, the code of the Serialization of the Spatial Pooler is built up as a docker image and then this image is pushed to the Azure Container Registry and the application then can be deployed using the Azure Container Instance service.

**Upload the Input File to blob storage:** The input files are uploaded to Azure blob storage in a JSON format to start the application.

**Send a Trigger message in Queue:** A particular message is sent in the Queue to trigger the training process.

**Perform Deserialization:** When the message from Queue is received, deserialization is performed, and the code gets triggered. The process of deserialization is needed here .Download input file from blob storage: Once the code gets triggered it will start downloading the input file from the Azure blob storage. 

**Run the testcases of Serialization of Spatial Pooler:** Since the required input file has already been downloaded the testcases should successfully executed taking that input as an argument.Download first output file from blob storage: The output file will be downloaded in order to subsequently check if it works with the deserializer function of spatial pooler and recreate the same spatial pooler object.

**Use the downloaded file in Spatial Pooler Deserialization function:** The downloaded file will be fed to deserializer function. Same instance of Spatial Pooler will be recreated.

**Upload Result/Output file to table and blob storage:** The output of the testcases will be uploaded to both table and blob storage.

**Delete message from Queue:** At last the queue message which we sent earlier to trigger the training process will be deleted.
