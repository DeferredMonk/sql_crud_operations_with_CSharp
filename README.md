# sql_crud_operations_with_csharp

This is an two part project with SQL and C#. 

1. The first part of the assignment (sql_crud_operations_with_csharp) deals with manipulating SQL Server data in Visual Studio using a SQL 
Client library. Database used in assignment is Chinook. The C# application is created in repository pattern.

2. The second part (SuperheroSQLQueries) deals with creating a SuperheroDb database. Sqripts written in SQL contains creation of tables, relationships and inserts, updates and deletes of data.  

## Technologies used

* C#
* SQL Client
* Microsoft SQL Server 19.0.1
* Microsoft SQL Server Management Studio

## sql_crud_operations_with_csharp Folder Structure
```
.
│   .gitattributes
│   .gitignore
│   README.md
│   sql_crud_operations_with_csharp.sln
│   
├───sql_crud_operations_with_csharp
│   │   Program.cs
│   │   sql_crud_operations_with_csharp.csproj
│   │   
│   ├───bin
│   ├───Models                                          #Includes database tables as structures
│   │       Customer.cs
│   │       CustomerCountry.cs
│   │       CustomerGenre.cs
│   │       CustomerSpender.cs
│   │       
│   ├───obj
│   └───Repositories
│       ├───Classes
│       │       CustomerCountryRepository.cs            #Query for customer by country structure
│       │       CustomerGenreRepository.cs              #Query for customers top genre/s 
│       │       CustomerRepository.cs                   #Queries for CRUD operatations
│       │       CustormerSpenderRepository.cs           #Query for maximum spender customers
│       │       
│       └───Interfaces                                  #Includes interfaces
│               ICrudRepository.cs  
│               ICustomerCountryRepository.cs
│               ICustomerGenreRepository.cs
│               ICustomerRepository.cs
│               ICustomerSpenderRepository.cs
│               
└───SuperheroSQLQueries                                 #Includes SQL queries
        01_dbCreate.Sql
        02_tableCreate.sql
        03_relationshipSuperheroAssistant.sql
        04_relationshipSuperheroPower.sql
        05_insertSuperheroes.sql
        06_insertAssistants.sql
        07_powers.sql
        08_updateSuperhero.sql
        09_deleteAssistant.sql
        SuperheroDiagram.PNG                           #SuperheroDb Diagramn in this readme
        
```

## SuperheroDB Diagram
![SuperheroDB diagram](/SuperheroSQLQueries/SuperheroDiagram.PNG)


## Authors
[@Heidi J](https://github.com/HeidiJoensuu)
[@Marco A](https://github.com/DeferredMonk)
[@Kirsi T](https://github.com/KipaTa)

## Sources
Project was an assignment done during education program created by Noroff Education
