
# Car Rental Project
It is the backend side of CarRental ReCap project made with .Net Core.

![ CarRental Project](https://github.com/cumalitezcan/Task1/blob/main/gifs/carrental.gif)

:red_car: This repository includes the backend of the car rental system. <br/>

## :tada: Getting Started

The project was developed in C#, in accordance with the multi-layered architecture and SOLID principles. CRUD operations were performed using the Entity Framework. MSSQL Localdb was used for database in the project. This system includes authentication and authorization. Users can only perform transactions for which they are authorized.
Implementations of JWT; Transaction, Cache, Validation and Performance aspects have been implemented. Fluent Validation support for Validation, 
Autofac support for IoC added. 
The project includes CRUD operations for car, brand, color, car images, user, operations claim, user operation claims, customer, credit card and rental. Car rental is carried out according to certain business rules. In addition, findeks scores increase according to the users' car rentals. Each car has its own findeks score. The user must have enough Findeks points to rent a car.

#### Technologies
- .NET Core
- Asp.NET for Restful Api
- MsSql
- Entity Framework Core
- Autofac
- Fluent Validation

#### Techniques
- Layered Architecture Design Pattern
- IOC
- AOP
- Autofac Dependency Resolver
- JWT


## :books: Layers
N-tier application architecture provides a flexible and reusable application model. For this reason, Layered Architecture Design Pattern was used in the car rental system.

![layers](https://user-images.githubusercontent.com/34379535/114321840-a50b2b80-9b25-11eb-94ab-b9fa0def85f7.PNG)

### :orange_book: [Entities Layer](https://github.com/cumalitezcan/ReCapProject/tree/master/Entities)
In this layer, the main classes to be used in the project are specified, that is, it is where the real objects are specified. <br/>
:open_file_folder: **Concrete folder:** Each of the classes in the concrete folder corresponds to a table in the database. <br/>
:open_file_folder: **DTOs folder:** Each of the classes in the DTOs folder contains DTO (Data Transfer Object) classes into which data from different tables are combined. <br/>

![entities](https://user-images.githubusercontent.com/34379535/114321871-e26fb900-9b25-11eb-8b01-ed665ed2766e.PNG)

### :green_book: [Data Access Layer](https://github.com/cumalitezcan/ReCapProject/tree/master/DataAccess)
In this layer, database connections and database operations are performed. Required configuration for database connection is done here. The task of this layer is to perform database CRUD operations. <br/>
:open_file_folder: **Abstract folder:** Abstract objects are found <br/>
:open_file_folder: **Concrete folder:** There are concrete objects for the Entity Framework, the context object, and the concrete objects for InMemory <br/>

![dataaccess](https://user-images.githubusercontent.com/34379535/114321873-e4d21300-9b25-11eb-8626-701e58e5c6a6.PNG)

### :blue_book: [Business Layer](https://github.com/cumalitezcan/ReCapProject/tree/master/Business)
It is the layer where business rules are defined and controlled,  that will take the data taken into the project by Data Access and process it. When a command comes to the program, what actions it should perform and which set of rules it should pass through are defined here. The data from the user first goes to the Business layer, and then processed and transferred to the Data Access layer. Business layer also specifies who will access these data. <br/>
:open_file_folder: **Abstract folder:** Services have abstract objects <br/>
:open_file_folder: **Concrete folder:** There are concrete service objects <br/>
:open_file_folder: **Constants folder:** Class of informative messages as a result of the transaction <br/>
:open_file_folder: **BusinessAspects:** Security operations management <br/>
:open_file_folder: **DependencyResolvers:** To create an instance <br/>
:open_file_folder: **ValidationRules:** Validation rules management <br/>

![Business](https://user-images.githubusercontent.com/34379535/114322034-c28cc500-9b26-11eb-9927-06d6c9c62707.PNG)

### :closed_book: [Core Layer](https://github.com/cumalitezcan/ReCapProject/tree/master/Core)
It is a universal layer with common codes. The core layer does not reference other layers, it is independent of the project. Items to be used in the core layer are classified according to other layers and their intended use. <br/>
![Core](https://user-images.githubusercontent.com/34379535/114322050-d801ef00-9b26-11eb-9761-9f507f3dd47b.PNG)

:open_file_folder: **Aspects folder:**  <br/>
![Aspect](https://user-images.githubusercontent.com/34379535/114322069-f23bcd00-9b26-11eb-8241-0f45a50211aa.PNG)

:open_file_folder: **CrossCuttingConcerns folder:**  <br/>
![CCC](https://user-images.githubusercontent.com/34379535/114322096-1a2b3080-9b27-11eb-8990-c1ae775b3fc6.PNG)

:open_file_folder: **DataAccess folder:** <br/>
![core dataaccess](https://user-images.githubusercontent.com/34379535/114322098-1d262100-9b27-11eb-988d-8d7a5a13c7b8.PNG)

:open_file_folder: **DependencyResolvers folder:** <br/>
![coredependencyresolvers](https://user-images.githubusercontent.com/34379535/114322288-f6b4b580-9b27-11eb-8b37-3e7516ee76ea.PNG)

:open_file_folder: **Entities folder:** <br/>
![core entities](https://user-images.githubusercontent.com/34379535/114322291-003e1d80-9b28-11eb-966f-7cc95f4ef2d4.PNG)

:open_file_folder: **Extensions folder:** <br/>
![core extentions](https://user-images.githubusercontent.com/34379535/114322319-2499fa00-9b28-11eb-8570-05a27051f35a.JPG)

:open_file_folder: **Utilities folder:** <br/>
![CoreUtilitie2](https://user-images.githubusercontent.com/34379535/114322377-92debc80-9b28-11eb-939b-aa4a762e5535.JPG)


### :open_book: [Web API](https://github.com/cumalitezcan/ReCapProject/tree/master/WebAPI)
It is the part where the services that enable the Front-End part and other platforms to communicate with the program and perform operations are written.

![web api](https://user-images.githubusercontent.com/34379535/114322383-9c682480-9b28-11eb-9a54-4d3f17fd9d75.PNG)

## :floppy_disk: Database
![Database](https://user-images.githubusercontent.com/34379535/114322387-9ffbab80-9b28-11eb-81eb-1bebcf238446.PNG)



## :package: Prerequisites
```
Autofac v6.1.0
Autofac.Extensions.DependencyInjection v7.1.0
Autofac.Extras.DynamicProxy v6.0.0
FluentValidation v9.5.1
Microsoft.AspNetCore.Authentication.JwtBearer v3.1.12
Microsoft.AspNetCore.Http v2.2.2
Microsoft.AspNetCore.Http.Abstractions v2.2.0
Microsoft.AspNetCore.Mvc.Core v2.2.5
Microsoft.EntityFrameworkCore.SqlServer v3.1.1
Microsoft.Extensions.DependencyInjection v5.0.1
Microsoft.IdentityModel.Tokens v6.8.0
NETStandart.Library v2.0.3
Newtonsoft.Json v13.0.1
System.IdentityModel.Tokens.Jwt v6.8.0

```

