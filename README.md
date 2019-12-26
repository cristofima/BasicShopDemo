# Basic Shop API REST

To build this project
```
dotnet restore 
```

Go to src\BasicShopDemo.Api

Configure the database settings in appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BasicShop;User ID=sa;Password=coronadoserver2018;Trusted_Connection=True;"
  }
}
```

To migrate to database
```
update-database -Context BasicShopContext
```

To run the project
```
dotnet run
```
