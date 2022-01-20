# Scannergic
# Introduction

### General idea of the project

Our idea is to develop an android application which would allow people with allergies to fill them in the app, scan the barcode of a product and quickly know if they can eat the product or not. So the application knows, according to the different allergies, which product can be eaten or not. To do this, the android app will be requesting the allergies contained in the product to an API.

The API will be developed in this part of the project so all the code you will find in it is related to the development of the API.

To get the other part of the project (Android App) please [click here](https://github.com/EliottJaquierCPNV/Scannergic)

### Goal

This application aims at simplifying people with allergies' life allowing them to quickly know if they can eat a product or not.

### Used technologies

API : ASP.NET / C#

Database : MySQL

### Schematic diagram

![SchémadePrincipe2](https://user-images.githubusercontent.com/61775725/141955527-72237c5a-a55d-431d-a332-4cf52c142d89.png)

## Prerequisites
### To run
Server side :
 - .NET runtime 5.0 : https://dotnet.microsoft.com/en-us/download/dotnet/5.0
 - MySQL community 8.0
### To collaborate
- Visual Studio 2019 Community or Enterprise with the following packages :
  Packages : https://visualstudio.microsoft.com/fr/vs/older-downloads/
   - WEB Development and ASP.NET

- A MySQL client, recommend Heidi : https://www.heidisql.com/download.php



#### To open documentation
- Draw.io / Diagrams.net : https://www.microsoft.com/fr-ch/p/drawio-diagrams/9mvvszk43qqw?activetab=pivot:overviewtab
- Astah Community / UML : https://astah.net/downloads/



#### How to setup the project

To clone the project run the following command :

```bash
git clone https://github.com/EliottJaquierCPNV/ScannergicBackendAPI
```

Then checkout on the right branch

```bash
git checkout develop
```

Once it is done you'll need to create the database with the script named **DatabaseCreation.sql** in **SQL scripts/**. Connect to your MySQL server using your Heidi or other SQL client and execute the script. If you want to put some test data in the DB to test the API, repeat the process with the **Population.sql** script.

Once done, go to **ScannergicBackendAPI\Scannergic\ScannergicAPI\credentials.json** and edit the database credentials to fit to yours.

Then go to the project folder where you cloned the project and click on the **.sln** file to open the project in Visual Studio. Run the project's tests by clicking this button : [capture]

In order ton run the project you need to click on this button :

[capture]

A web page will open in your browser and you should see this 

[capture swagger]

From there you can try the API and you're all set !



**Note :** you only need to run the project, on a server for example please follow the process described in the wiki.

