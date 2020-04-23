# Visual Studio Toolbox - Entity Framework Core
## How to use entity framework core

https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Entity-Framework-Core-Part-1
https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Entity-Framework-Core-Part-2
https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Entity-Framework-Core-Part-3

NOTES:
https://github.com/chrissc6/EFCoreBasicsCH9/blob/master/CH9EFCoreNotes.docx


Create Console App (.NET Core)

NuGet Packages
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer

Install AdventureWorks2016.bak - localdb
https://docs.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver15

Install a global tool
dotnet tool install -g dotnetsay
https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools

dotnet tool install --global dotnet-ef
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet

dotnet ef

scaffold and dbcontext -
dotnet ef dbcontext scaffold "server=(localdb)\mssqllocaldb;Database=Adventureworks2016;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -d -c AwDbContext --context-dir EfStructures -o Entities 

