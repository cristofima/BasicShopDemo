# Basic Shop API REST

To build this project
```
dotnet restore 
```

Go to src\BasicShopDemo.Api

Configure the database and SMTP settings in appsettings.json

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
   "SMTP_Options": {
    "Server": "smtp-mail.outlook.com",
    "Username": "xxxxxxxxxxx@outlook.com",
    "Password": "xxxxxxxxx",
    "Port": 587,
    "EnableSsl": true
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
