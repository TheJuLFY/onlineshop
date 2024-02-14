*How to update current database using initial migration?*


1. Install dotnet ef as a global util using command:

		dotnet tool install --global dotnet-ef --version <number of your EF core version>

1. Create initial migration:

        dotnet-ef migrations add <name> --project Infrastructure --startup-project WebApi 

3. Update your DB after new migration:

		dotnet-ef database update --project Infrastructure --startup-project WebApi 