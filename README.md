# Develop for Azure Storage - Azure Storage Accounts


## Create Storage Account

<img src="/pictures/create_storage_account.png" title="create storage account"  width="900">


## Blob Service

- create container with private access level
<img src="/pictures/create_container.png" title="create container"  width="900">

- upload files. They will be stored as BLOB. Yoy can edit text files directly on the Azure portal.
<img src="/pictures/create_container2.png" title="create container"  width="900">

- because of the private access level, it is not accessible by url.
<img src="/pictures/create_container3.png" title="create container"  width="900">
<img src="/pictures/create_container2.png" title="create container"  width="900">

- set the access level as blob in order to access it by url 


## Access Keys

- in the *Access Keys* section, grab the key1
<img src="/pictures/access_keys.png" title="access keys"  width="900">

- in *Microsoft Azure Storage Explorer*, add a connection to Storage Account
<img src="/pictures/access_keys2.png" title="access keys"  width="900">

- choose *Account Name and Key*, then paste the key and fill out the form
<img src="/pictures/access_keys3.png" title="access keys"  width="900">

- you should end up being connected and the uploaded files
<img src="/pictures/access_keys4.png" title="access keys"  width="900">


## Shared Access Signatures - Blob

- choose a blob that has private access, and go to the *Generate SAS* section. It will generate a unique signature for accessing that particular blob.
<img src="/pictures/sas.png" title="shared access signatures"  width="900">

- you can grab the generated url to access that object


## Shared Access Signatures - Storage Account Level

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


## Stored Access policies

- inside a container, go to the *Access Policy* section and clic *Add a policy* for *stored Access Policies*
<img src="/pictures/sap.png" title="stored access policy"  width="900">


## Azure Active Directory Authentication

- inside Azure Active Directory, create a user

- inside *Storage Accounts*, add a new reader role
<img src="/pictures/ad.png" title="azure active directory"  width="900">

- choose a user and give it a role assignment
<img src="/pictures/ad2.png" title="azure active directory"  width="900">

- in *Microsoft Azure Storage Explorer*, connect through the newly created user


## Creating a Container

- in visual studio, create a console app and install following packages :
```
Azure.Storage.Blobs
```


## Properties

- 

