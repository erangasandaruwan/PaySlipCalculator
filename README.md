# Pay Slip Calculator

What is Pay Slip Calculator ?
------------------------------------
Pay Slip Calculator is a web application which can be used to generate payment details. The application contains single micro service to calculate pay details.

Tech stack
------------------------------------

+ Front-end 
  + **Angular** 14 with **Bootstrap**.
+ Back-end
  + .Net core 3.1 incluing **MediatR**, **Fluent validation** & **AutoMapper** with **Nlog** logging
  + **MS SQL Server** & **Entity Core** 
  + **Cache in-memory** with ASP.NET Core
  + **Swagger** as the specification of th APis
+ Test
  + Unit test with **xUnit** & **Moq**

How to run the solution ?
------------------------------------
### Running the code 
#### Back-end/ Microservices -
The back-end application is implemented with entity core (EF Core)  and built to work with a MS SQL Server database for data/storage usage. Here, code first approach is being used and Database Migration and Seeds are available with the solution **PaySlip.DbMigration**. (_Expected to run the solution with Visual Studio_)
+ First, create an empty database with an available/ accessible MS SQL Server.
+ DB Connectivity - Update the connection string with **PaySlipDbContext** inside appsettings.json file of the solution **PaySlip.Api**.
+ Migrations - Run the command **`Update-database`** to create the tables and insert seeds with Tax Rates.
+ Run the solution from Visual Studio else deploy the solution to IIS Server (Please refer the steps here - [Publish an ASP.NET Core app to IIS](https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-6.0&tabs=visual-studio)).
+ Run the solution with Docker - From terminal go into src folder, Run **`docker compose up`** and Open http://localhost:5001 on the browser.
+ Swagger - Open https://localhost:5001/swagger/index.html on the browser.
  ![image](https://user-images.githubusercontent.com/25504137/199136516-bdc07ffa-3532-4345-b6b7-a3d75fc3b4e0.png)

#### Fron-end/ Angular App -
The angular application is a simple interface implemented to invoke the back-end API. (_Expected to run the solution with Visual Studio Code_)
+ Install angular cli running the command **`npm i @angular/cli`**
+ Run the command **`npm install`** to install/update the required packages.
+ Run the comman **`ng serve`** to run the solution and Open http://localhost:4200 on the browser.
  ![image](https://user-images.githubusercontent.com/25504137/199137772-beb4f7ed-08db-428f-baec-e6e8bb144342.png)

Assumptions
------------------------------------
+ No Authentication.
+ Consistancy over performance.
+ Back-end - Tax Rates will not get frequently get updated, else it is required to re-deploy the solution.
+ Front-end - Will always depend on language/culture with US-English. Else we need to fetch Pay Period details from the a API.

Next Steps
------------------------------------
+ Back-end - Implement a distributed caching mechanism and cache expiring mechanism.
+ Front-end - Add unit tests to Front-end(Karma with Angular).
+ Front-end - Make the UI more user friendly.
+ Front-end - Implement state management using angular store, actions, reduces and effects.
  ![image](https://user-images.githubusercontent.com/25504137/199139435-066f0ea1-aa5f-44f3-8fff-f39cae5ca69e.png)


