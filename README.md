# Basic Shop API REST

To build this project
```
dotnet restore 
```

Go to src\BasicShopDemo.Api

Configure the database and [Mailjet](https://www.mailjet.com/) settings in appsettings.json

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
  },
  "EmailSenderOptions": {
    "ApiKey": "xxxxxxxxxxxxxxxxxxxx",
    "ApiSecret": "xxxxxxxxxxxxxxxxxx",
    "FromEmail": "[Sender email address available in your Mailjet account]",
    "FromName": "Basic Shop Demo"
  }
}
```

To migrate to database
```
update-database -Context BasicShopContext
update-database -Context ApplicationDbContext
```

To run the project
```
dotnet run
```
To run the tests
```
dotnet test
```
