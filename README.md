# Pay Slip Calculator

What is Pay Slip Calculator ?
------------------------------------
Pay Slip Calculator is a web application which can be used to generate payment details. The application contains single micro service to calculate pay details.

Tech stack
------------------------------------

+ Front-end 
  + angular 14.
+ Back-end
  + .Net core 3.1 incluing **MediatR**, **Fluent validation** & **AutoMapper** with **Nlog** logging
  + **MS SQL Server** & **Entity Core** 
  + **Cache in-memory** with ASP.NET Core
  + **Swagger** as the specification of th APis
+ Test
  + Unit test with **xUnit** & **Moq**

How to run the solution ?
------------------------------------
# Running the code 
## Back-end/ Microservice
The back-end application is implemented with entity core (EF Core)  and built to work with a MS SQL Server database for data/storage usage. Here, code first approach is being used and Database Migration and Seeds are available with the solution **PaySlip.DbMigration**.
+ First, create an empty database with an available/ accessible MS SQL Server.
+ DB Connectivity - Update the connection string with **PaySlipDbContext** inside appsettings.json file of the solution **PaySlip.Api**.
+ Migrations - Run the command **`Update-database`** to create the tables and insert seeds with Tax Rates.
+ Run the solution from Visual Studio else deploy the solution to IIS Server (Please refer the steps here - [Publish an ASP.NET Core app to IIS](https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-6.0&tabs=visual-studio)).
+ Run the solution with Docker - From terminal go into src folder, Run **`docker compose up`** and Open http://localhost:5001 on the browser.
+ Swagger - Open https://localhost:5001/swagger/index.html on the browser.
  ![image](https://user-images.githubusercontent.com/25504137/199136516-bdc07ffa-3532-4345-b6b7-a3d75fc3b4e0.png)


