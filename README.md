# Product Stock Manager API

This is an API built for managing products in a store endpoints include

```sh
 api/products - GET           //To get list of products with category, it also includes stores where products are found
 api/products - POST          //Use endpoint to create a new product, this can be extended to allow bulk creation of products
 api/products/ProductGroups   //This can be used to get ProductGroups with their sub groups in a tree like manner
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

## Using POSTMAN test the endpoint for creating a new product with the data below 
 It allows for adding products across stores as this if their prices are the same
 ```sh
{
    "productId": "1",
	"productName": "Resident Good 4",
	"productGroupId": "4",
	"price": "25.00",
	"priceWithVat":"28.00",
	"vatRate": "20",
	"stores": [1,2,3]
}
```
