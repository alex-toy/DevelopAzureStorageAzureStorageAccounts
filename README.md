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
