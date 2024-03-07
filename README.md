# CPW219-eCommerceSite
The purpose of this project is to get experience in using [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet), [CRUD Functionality](https://www.sumologic.com/glossary/crud/), [Bootstrap](https://getbootstrap.com/docs/5.3/getting-started/introduction/) and [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) in Microsoft Visual Studio.

## The Project
For the time being, the project is simply a testing ground of sorts to get used to the concepts listed above. This version of the assignment is tailored to mimic a website for a fictional café, specifically what food and beverage items are available for purchase. A database was created alongside this project in order to keep track of these items, as well as maintain order in the code overall.
![Screenshot (521)](https://github.com/Wesli-S/CPW219-eCommerceSite/assets/146999017/7610bee3-640f-4d94-98ee-f9c0d4c62f37)

---
## Prerequisites
- Visual Studio 2022 (or higher)
- .NET Version 8.0 
- NuGet Packages

## How to Install Database
1. Make sure all necessary NuGet packages are installed:
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
      
_Once your NuGet packages have finished installing:_   
2. Open the **Package Manager** (Tools -> NuGet Package Manager -> Package Manager Console)   
3. Execute the command `Update-Database` (no spaces!)   
4. Check your **SQL Server Object Explorer** for the **CPW211_MurderMystery database** under localdb.    
5. Done!  
