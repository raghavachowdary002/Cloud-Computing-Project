# Cloud-Computing-Project
This Project was to deploy already developed project called Serialization of Spatial Pooler on Microsoft Azure Cloud. The Serialization of Spatial Pooler project was to integrate feasible serialization technique in Spatial pooler module in .NET environment.

# Overview of Serialization of Spatial Pooler
Hierarchical temporal memory (HTM), inspired by the architecture and functionality of Neocortex, is designed to learn sequences and make predictions. Vast amount of information is fed to our brain through our sensory systems which remodels raw external data from light, sound pressure, skin deformations etc. In order to organize these data and constitute our  perceptibility cortical neurons forms synaptic connections to a subset of the presynaptic neurons. This learning mechanism by cortical neurons to specific input patterns and collective input specific representation of a population of neurons inspires the algorithmic property of Hierarchical temporal memory. Two primary algorithms of the current version of HTM are Spatial Pooler (SP) and Temporal Memory (TM). The SP takes a binary input and produces a new Sparse Distributed Representation (SDR) of the input, here an SDR is a binary vector typically having a sparse number of active bits, i.e., a bit with a value of “1”. Hence SP works as a mapping function that transforms input domain to a feature domain. The mapped output from Spatial Pooler in the form of SDR Data is then subsequently fed to Temporal Memory.  Serialization is the process of converting an object 
into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed. The HTM Spatial Pooler software model incorporates complex data handling constituted by different type of properties. In the previously implemented Software Engineering Project, JSON serialization technique was used to serialize and deserialize the properties of Spatial Pooler object. Special calibrations were done in JSON serializer settings to handle complex type serialization. Member Serialization attributes had to be used in Spatial Pooler class and its constituent property class Connections. The serialization model was successfully tested to store all the properties of a trained Spatial Pooler object model into a file (of JSON,.txt or relevant extensions) and subsequently was capable of recreating the same Spatial Pooler object from that file through the deserialization model.
