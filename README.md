# Product Stock Manager API

This is an API built for managing products in a store endpoints include

```sh
 api/products  //To get list of products with category, it also includes stores where products are found
 api/CreateProduct //Use endpoint to create a new product, this can be extended to allow bulk creation of products
 api/ProductGroups //This can be used to get ProductGroups with their sub groups in a tree like manner
```

## Running
* Clone or download the repository
* Open the project in either Visual Studio or IntelliJ Rider 
* Change the ConnectionStrings in appsettings.json to localdb or an SQL Instance
* Ensure that the nuget packages are restored once the products is launched the seed method will run

## Improvements
The ProductGroups endpoint can be optmized to use an iterative approach instead of recursion
API can be extended to allow for Bulk Insert
Versioning can be added for the projects etc

