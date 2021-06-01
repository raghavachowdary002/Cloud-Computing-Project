# My Exercises

## Exercise I 

1.Unlock Azure Subscription:

To create Microsoft Azure Account - [Azure Account Creation](https://lnkd.in/e-FRrCc)
To unlock Subscription - [Unlock Subscription](https://azure.microsoft.com/en-us/offers/ms-azr-0144p/)

2.Create Github account:

To create github account - [Github Account Creation](https://github.com/join)

3.Install Docker Desktop:

Steps to install Docker Desktop(Windows) - [Install Docker Desktop(Windows)](https://docs.docker.com/docker-for-windows/install/)
Steps to install Docker Desktop(MAC) - [Install Docker Desktop(MAC)](https://docs.docker.com/docker-for-mac/install/)

4.Login az through command prompt/terminal: [AZ login](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2019-2020/blob/LakshmiMounikaKolisetty/MyWorkCC/Exercise-1/Exercise-1.md)

## Exercise 2 - Docker in Azure

1. URL to the docker file:
i.e.:[Docker File](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2019-2020/blob/LakshmiMounikaKolisetty/Source/MyCloudProjectSample/Exercises/Dockerimagec/Dockerimagec/Dockerfile)

2. URL to the public image in the Docker Hub:
[URL](https://hub.docker.com/r/80480876/dockerimage)

>Pull the image using:
>docker pull 80480876/dockerimage

3. Provide the URL to the private(public??) image in the Azure Registry:
>The image pushed into the Registry is private.
URL to the private image in Azure Registry:
[URL](https://portal.azure.com/#@mounikolisettygmail.onmicrosoft.com/resource/subscriptions/b5895414-ce43-4438-b51d-ccadffdff4a6/resourceGroups/DockerimageR/providers/Microsoft.ContainerRegistry/registries/Dockerimagear/repository)

>Pull the image using:
>docker pull dockerimagear.azurecr.io/dockerimage:v1

## Exercise 3 - Host a web application with Azure App service

1. Provide the public URL of the webapplication.[URL](https://webappexercise.azurewebsites.net)
2. Provide the URL to the source code of the hosted application. (Source code somwhere or the the docker image, or ??)
[URL](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2019-2020/tree/LakshmiMounikaKolisetty/MyWorkCC/Exercise-3/WebappExercise)
3. Provide AZ scripts used to publish the application.
>**To create ASP.NET core MVC application**
>dotnet new mvc --name <NameOfTheApp>
**Build and run the application**
>cd <NameOfTheApp>
>dotnet run
**Build final app files and zip them into a zip file**
>dotnet publish -o pub
>cd pub
>zip -r site.zip *
**To deploy use following command**
>az webapp deployment source config-zip --src site.zip --resource-group <ResourceGroupName> --name <YourUniqueAppName>
>Navigate to the webapp created in azure portal and click browse to verify the deployment

#### Exercise 4 - Deploy and run the containerized app in AppService

1. Provide URL to the docker image of your application (Docker Hub / Azure Registry)
[URL](https://hub.docker.com/repository/docker/80480876/dockerimage)
2. Provide the public URL to the running application. 
[URL](https://webimage-ex4.azurewebsites.net/)

#### Exercise 5 - Blob Storage

Provide the URL to to blob storage container under your account.
[URL](https://portal.azure.com/#@mounikolisettygmail.onmicrosoft.com/resource/subscriptions/b5895414-ce43-4438-b51d-ccadffdff4a6/resourcegroups/DockerimageR/providers/Microsoft.Storage/storageAccounts/storageaccountex/containersList)

Created Test file download URL :
[URL](https://storageaccountex.blob.core.windows.net/ex5blobad9b4a8b-273d-41e6-aea0-cf1d213c5c92/quickstart48142ef7-cb9f-4d27-b433-b05716b16f23.txt)
#### Exercise 6 - Table Storage

Table Storage The account which you have used for table exersises: 
[URL](https://portal.azure.com/?nonceErrorSeen=true#@stud.fra-uas.de/resource/subscriptions/b4828c4a-25da-4a12-a75c-d458eefaff94/resourcegroups/CC-20/providers/Microsoft.DocumentDB/databaseAccounts/testex6table/overview)

Azure Cosmos DB table :
[URL](https://cosmos.azure.com/?key=4g92eQsGf5kvEGN7HTwdImmfaj%2fTBsLt3mrsuALkZfzedyiEVFEOGbmkFO8D0SgX42wTqu07Q4U6dvOl2O2kFn943YaZYEBQ3uTaZR7e%2bqYeodkHlS%2bgRk%2fXkQJR4Gags7eGLHCbr693%2borrulUfP3c04w%2bKelSximl8mkMoAkw%3d%26mWLruszmIqOAWfyPs7%2fNcqKyaOICyZv4%2fZVUuKD1gFKsI7aUuWr%2bMuAh7DXe3bFZ6rMX1sZEynPOZxIzAS9s5UGI11rXqYMUiQN%2bHeVB4kbGvl5jW0yjbUsUccknszUTGAGNHZAIRXyWWjp%2bGPOpcUaucOItMek%2foYgP5%2f%2b53GDn8YWYWoBTcesvLidJegd%2f0SbYL0FgyBZ9gAk2D1Q%2bZnAnUYCe0gjw%2fRiCtLIKhGTeSe%2bWwtB00cDV17q5OfEgp2Suwv%2fzoOwqIGzDnvF9BWa%2fotVJzXXvxg7E84azXvATVP7FPY0sXkb5TOut7Hzh4lXzHOA3LjJ3XIdXHwvV9Q%3d%3d#/dbs/TablesDB/colls/demo649b3/entities)

#### Exercise 7 - Queue Storage

Queue Storage The account which you have used for queue exersises: 
[URL](https://portal.azure.com/?Microsoft_Azure_Education_correlationId=fe7f72fe-9420-4e47-8a70-6298a698c1d1#blade/Microsoft_Azure_Storage/QueueMenuBlade/overview/storageAccountId/%2Fsubscriptions%2F89732d46-4823-440e-958f-44b825badbd9%2FresourceGroups%2Fcreate%2Fproviders%2FMicrosoft.Storage%2FstorageAccounts%2Fmystorage307/queueName/trigger-queue)

