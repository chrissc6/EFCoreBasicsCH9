# Visual Studio Toolbox - Entity Framework Core
## How to use EF Core

https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Entity-Framework-Core-Part-1

https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Entity-Framework-Core-Part-2

https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Entity-Framework-Core-Part-3


My notes:<br/>
https://github.com/chrissc6/EFCoreBasicsCH9/blob/master/CH9EFCoreNotes.docx

Actual show notes:<br/>
https://github.com/skimedic/presentations/tree/master/DOTNETCORE/EntityFrameworkCore


Create Console App (.NET Core)<br/>


NuGet Packages<br/>
Microsoft.EntityFrameworkCore.Design <br/>
Microsoft.EntityFrameworkCore.SqlServer <br/>


Install AdventureWorks2016.bak - localdb<br/>
https://docs.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver15


Install a global tool<br/>
dotnet tool install -g dotnetsay<br/>
https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools


dotnet tool install --global dotnet-ef<br/>
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet


dotnet ef<br/>

scaffold and dbcontext -<br/>
dotnet ef dbcontext scaffold "server=(localdb)\mssqllocaldb;Database=Adventureworks2016;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -d -c AwDbContext --context-dir EfStructures -o Entities 



