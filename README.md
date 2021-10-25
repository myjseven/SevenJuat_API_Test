# SevenJuat_API_Test
DO THE FOLLOWING BEFORE RUNNING THE CODE

BEFORE MIGRATION
1. Update ConnectionString in the appsettings.json
2. Install NugetPackages
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools

MIGRATION
1. Delete the Migrations Folder
2. Open Tools>Nuget Package Manager>Package Manager Console
3. Type add-migration InitialMigration and then Enter
4. Type update-database and then Enter

ASSUMPTIONS/LIMITATIONS
1. Account login is not included
2. Default Balance upon creation of Account is 100
3. Payment Status are "Pending" and "Paid"

API can be tested using Postman or the built-in Swagger in VS (Provided on Run)
