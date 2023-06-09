# Develop for Azure Storage - Azure Storage Accounts

## Storage Account

### Create Storage Account

<img src="/pictures/create_storage_account.png" title="create storage account"  width="900">


### Blob Service

- create container with private access level
<img src="/pictures/create_container.png" title="create container"  width="900">

- upload files. They will be stored as BLOB. Yoy can edit text files directly on the Azure portal.
<img src="/pictures/create_container2.png" title="create container"  width="900">

- because of the private access level, it is not accessible by url.
<img src="/pictures/create_container3.png" title="create container"  width="900">
<img src="/pictures/create_container2.png" title="create container"  width="900">

- set the access level as blob in order to access it by url 


### Access Keys

- in the *Access Keys* section, grab the key1
<img src="/pictures/access_keys.png" title="access keys"  width="900">

- in *Microsoft Azure Storage Explorer*, add a connection to Storage Account
<img src="/pictures/access_keys2.png" title="access keys"  width="900">

- choose *Account Name and Key*, then paste the key and fill out the form
<img src="/pictures/access_keys3.png" title="access keys"  width="900">

- you should end up being connected and the uploaded files
<img src="/pictures/access_keys4.png" title="access keys"  width="900">


### Shared Access Signatures - Blob

- choose a blob that has private access, and go to the *Generate SAS* section. It will generate a unique signature for accessing that particular blob.
<img src="/pictures/sas.png" title="shared access signatures"  width="900">

- you can grab the generated url to access that object


### Shared Access Signatures - Storage Account Level

- at the storage account level, go to the *Shared Access Signature* section
<img src="/pictures/sas_storage_account.png" title="shared access signatures - storage account level"  width="900">

- you need to provide the *allowed resource types*. Choose all three (service, container and object)

- in *Microsoft Azure Storage Explorer*, add a connection to Storage Account

- choose *Shared Access Signature*
<img src="/pictures/sas_storage_account2.png" title="shared access signatures - storage account level"  width="900">

- grab the url from the *Azure Portal* and fill out the form
<img src="/pictures/sas_storage_account3.png" title="shared access signatures - storage account level"  width="900">

- you should end up connected and able to access data
<img src="/pictures/sas_storage_account4.png" title="shared access signatures - storage account level"  width="900">

- notice you can't delete an object, according to your settings an SAS
<img src="/pictures/sas_storage_account5.png" title="shared access signatures - storage account level"  width="900">


### Stored Access policies

- inside a container, go to the *Access Policy* section and clic *Add a policy* for *stored Access Policies*
<img src="/pictures/sap.png" title="stored access policy"  width="900">


### Azure Active Directory Authentication

- inside Azure Active Directory, create a user

- inside *Storage Accounts*, add a new reader role
<img src="/pictures/ad.png" title="azure active directory"  width="900">

- choose a user and give it a role assignment
<img src="/pictures/ad2.png" title="azure active directory"  width="900">

- in *Microsoft Azure Storage Explorer*, connect through the newly created user


### Creating a Container

- in visual studio, create a console app and install following packages :
```
Azure.Storage.Blobs
```


### Metadata

- let's add some metadata to our blob
<img src="/pictures/metadata.png" title="metadata"  width="900">

- let's retrieve that metadata programatically
<img src="/pictures/metadata2.png" title="metadata"  width="900">


### Storage Lease

- acquire a lease on a blob on the azure portal. A lease acts like a sepaphore
<img src="/pictures/lease.png" title="lease"  width="900">

- you can as well break the lease on the portal


### ARM Template

- create a template : *Template deployment*, then *Build your own template*
<img src="/pictures/arm.png" title="ARM tempalte"  width="500">


### Az Copy tool

- get a SAS 
<img src="/pictures/copy_tool.png" title="Az Copy tool"  width="900">

- create a container *myfiles*
<img src="/pictures/copy_tool1.png" title="Az Copy tool"  width="900">
<img src="/pictures/copy_tool2.png" title="Az Copy tool"  width="900">

- upload file *commands.txt* to container *myfiles*
<img src="/pictures/copy_tool3.png" title="Az Copy tool"  width="900">
<img src="/pictures/copy_tool4.png" title="Az Copy tool"  width="900">


### Azure File Share

It's the concept of sharing files between multiple users.

- create a file share
<img src="/pictures/file_share.png" title="file share"  width="900">

- clic connect and copy the script
<img src="/pictures/file_share2.png" title="file share"  width="900">


## Table Storage

### Azure Table Storage in the Azure Portal

<img src="/pictures/table_storage.png" title="table storage"  width="900">
<img src="/pictures/table_storage1.png" title="table storage"  width="900">

### Create Table programmatically

- install package
```
Microsoft.Azure.Cosmos.Table
```

- add Entity 
<img src="/pictures/add_entity.png" title="add entity"  width="900">

- add Entities in a batch
<img src="/pictures/add_entity2.png" title="add entity"  width="900">

- read entities
<img src="/pictures/add_entity3.png" title="read entity"  width="900">

- update entities
<img src="/pictures/add_entity4.png" title="update entity"  width="900">

- delete entities
<img src="/pictures/add_entity5.png" title="delete entity"  width="900">


## Queue Service

### Azure Queue Storage in the Azure Portal

- create a queue and add a message into it
<img src="/pictures/queue_storage.png" title="queue storage"  width="900">
<img src="/pictures/queue_storage2.png" title="queue storage"  width="900">

### Create Queue programmatically

- install package
```
Azure.Storage.Queues
```

- create queue
<img src="/pictures/queue.png" title="queue"  width="900">

- add messages to the queue
<img src="/pictures/queue1.png" title="queue"  width="900">

- peek messages. You can read messages but leave them on the queue for later processing
<img src="/pictures/queue2.png" title="queue"  width="900">

- receive messages. This will pop a message off the queue
<img src="/pictures/queue3.png" title="queue"  width="900">


## Queue Trigger

### Create Azure Function

- choose *Queue Trigger*
<img src="/pictures/azure_function.png" title="azure function"  width="900">

When you run the *GetMessages* function, you get a lot of errors and a new queue is automatically created.
<img src="/pictures/azure_function2.png" title="azure function"  width="900">

This is because we need to base-64 encode our messages. Let's encode our messages before sending them to the queue
<img src="/pictures/azure_function3.png" title="azure function"  width="900">

and run our queue trigger again and successfully retrieve our messages by means of an azure function.
<img src="/pictures/azure_function4.png" title="azure function"  width="900">

### Table Output

- add a table *Orders*
<img src="/pictures/table_output.png" title="table output"  width="900">

- run the function. It is now waiting for messages on the queue
<img src="/pictures/table_output2.png" title="table output"  width="900">

- add a message on the queue
<img src="/pictures/table_output3.png" title="table output"  width="900">

- the message will be immediately processed
<img src="/pictures/table_output4.png" title="table output"  width="900">

and has disappeared from the queue
<img src="/pictures/table_output5.png" title="table output"  width="900">

and is now available on the *Orders* table
<img src="/pictures/table_output6.png" title="table output"  width="900">





