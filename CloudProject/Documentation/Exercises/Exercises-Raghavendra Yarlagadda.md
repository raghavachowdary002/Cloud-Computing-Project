# My Exercises

#### Exercise I 

##Unlock Azure Subscription:

To create Microsoft Azure Account -[click here](https://lnkd.in/e-FRrCc)
To unlock Subscription - [click here](https://azure.microsoft.com/en-us/offers/ms-azr-0144p/)

##Create Github account:

To create github account -[click here](https://github.com/join)

##Install Docker Desktop:

Steps to install Docker Desktop(Windows) -[click here](https://docs.docker.com/docker-for-windows/install/)
Steps to install Docker Desktop(MAC) - [click here](https://docs.docker.com/docker-for-mac/install/)

##Login az through command prompt/terminal:

>az login (running this command lists all the available subscriptions as shown below)
>{
 >"cloudName": "AzureCloud",
 >"homeTenantId": "eae00579-9fd4-4888-b6d6-bf83f6d9feed",
 >"id": "af00c8e9-a0ac-4376-a728-eabfe9cc6f1a",
 >"isDefault": true,
 >"managedByTenants": [],
 >"name": "Free Trial",
 >"state": "Enabled",
 >"tenantId": "eae00579-9fd4-4888-b6d6-bf83f6d9feed",
 >"user": { "name": "raghavachowdary002@gmail.com", "type": "user" }
>}


>az account show (displays the detailed description about the active subscription:can be found under 'name' as shown below)
>
>{
 >"cloudName": "AzureCloud",
 >"homeTenantId": "eae00579-9fd4-4888-b6d6-bf83f6d9feed",
 >"id": "af00c8e9-a0ac-4376-a728-eabfe9cc6f1a",
 >"isDefault": true,
 >"managedByTenants": [],
 >"name": "Free Trial",
 >"state": "Enabled",
 >"tenantId": "eae00579-9fd4-4888-b6d6-bf83f6d9feed",
 >"user": { "name": "raghavachowdary002@gmail.com", "type": "user" }
>}

>All the resources created will be under this subscription.
>To change the subscription run the following commands az account list (list of all the accounts)
>az account set -s (set/change account to desired subscription using id/name)

#### Exercise 2 - Docker in Azure

1. URL to the docker file:
I.e.:[URL](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2019-2020/blob/raghav/Cloud%20Exercises/Consoleapplication%20ex2/Dockerfile)

2. URL to the publich image in the Docker Hub:
[URL](https://hub.docker.com/r/iamraghav/dockerimage)

Pull the image using:
docker pull iamraghav/dockerimage

3. Provide the URL to the private(public??) image in the Azure Registry:
The image pushed into the Registry is private.
URL to the private image in Azure Registry:
[URL](https://portal.azure.com/#@raghavachowdary002gmail.onmicrosoft.com/resource/subscriptions/af00c8e9-a0ac-4376-a728-eabfe9cc6f1a/resourceGroups/ccexercise/providers/Microsoft.ContainerRegistry/registries/containerregrag/repository)

Pull the image using:
docker pull containerregrag.azurecr.io/dockerimage:v1

#### Exercise 3 - Host a web application with Azure App service

1. Provide the public URL of the webapplication- [URL](https://webappexercise.azurewebsites.net/)
2. Provide the URL to the source code of the hosted application. (Source code somwhere or the the docker image, or ??)
[URL](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2019-2020/tree/raghav/Cloud%20Exercises/ex3app)
3. Provide AZ scripts used to publish the application.
>'To create ASP.NET core MVC application'
>dotnet new mvc --name <NameOfTheApp>
>'Build and run the application'
>cd <NameOfTheApp>
>dotnet run
>'Build final app files and zip them into a zip file'
>dotnet publish -o pub
>cd pub
>zip -r site.zip *
>'To deploy use following command'
>az webapp deployment source config-zip --src site.zip --resource-group <ResourceGroupName> --name <YourUniqueAppName>
>Navigate to the webapp created in azure portal and click browse to verify the deployment

#### Exercise 4 - Deploy and run the containerized app in AppService

1. Provide URL to the docker image of your application (Docker Hub / Azure Registry)
   [URL](https://hub.docker.com/repository/docker/iamraghav/dockerdemoapplication)
   
2. Provide the public URL to the running application. 
   [URL](https://webimage-ex4.azurewebsites.net)

#### Exercise 5 - Blob Storage

Provide the URL to to blob storage container under your account.
[URL](https://portal.azure.com/#@raghavachowdary002gmail.onmicrosoft.com/resource/subscriptions/af00c8e9-a0ac-4376-a728-eabfe9cc6f1a/resourcegroups/GroupSW/providers/Microsoft.Storage/storageAccounts/groupsw/containersList)
Created Test file download URL :
[URL](https://groupsw.blob.core.windows.net/ex5blobd34ac2cd-6b12-4b48-8f0a-321ad060a1e7/quickstart98a75b24-7b92-4b21-872f-944aa5b38663.txt)

#### Exercise 6 - Table Storage

Provide us access to the account which you have used for table exersises.
 [URL](https://portal.azure.com/?nonceErrorSeen=true#@stud.fra-uas.de/resource/subscriptions/b4828c4a-25da-4a12-a75c-d458eefaff94/resourcegroups/CC-20/providers/Microsoft.DocumentDB/databaseAccounts/testex6table/overview)
#### Exercise 7 - Queue Storage

Provide us access to the account which you have used for queue exersises.
[URL](https://portal.azure.com/?Microsoft_Azure_Education_correlationId=fe7f72fe-9420-4e47-8a70-6298a698c1d1#blade/Microsoft_Azure_Storage/QueueMenuBlade/overview/storageAccountId/%2Fsubscriptions%2F89732d46-4823-440e-958f-44b825badbd9%2FresourceGroups%2Fcreate%2Fproviders%2FMicrosoft.Storage%2FstorageAccounts%2Fmystorage307/queueName/trigger-queue)

