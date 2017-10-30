Project setup

- Extract zip contents and open solution file using Visual Studio 2017 (should also work with VS 2015 but not tested)
- Right-click solution and click Restore Nuget Packages
- Set MyMovies.Web project as Startup project
- Go to Tools > Nuget Package Manager > Click Package Manager Console
- In the Package Manager Console, on the Options bar, set the Default project as MyMovies.Data and type update-database and press Enter
- Press F5 to start the web project

Solution design

Architecture: 3-tier
- Data Layer: MyMovies.Data (Repository Pattern using Entity Framework)
- Domain/Business Layer: MyMovies.Domain (Facade Pattern implementation using services)
- Presentation Layer: MyMovies.Web (MVC + Dependency Injection Principle using Ninject Ioc)

Technical requirements

- ASP.NET MVC 5
- .NET Framework 4.6.2
- SQL Server 2008 R2 or higher