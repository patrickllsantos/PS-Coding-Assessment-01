# Coding Assessment

## Installation

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) (or another compatible database)
- [Docker](https://www.docker.com/get-started) (optional, for running the database in a container)

### 1.) Clone the Repository

```sh
git clone https://github.com/patrickllsantos/Patrick-Santos-Ehrlich-Coding-Assessment.git
cd repository-name
```

### 2.) Install dependencies

```sh
dotnet restore
```

### 3.) Setup database 

a. Create your postgres db manually

b. Use docker by running:
```sh
docker-compose up -d
```
   
### 4.) Configure db connection

Create the ff. files:
```sh
appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

```sh
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=DB_NAME_INSERT;User ID=USER_INSERT;Password=PASSWORD_INSERT;Port=PORT_INSERT;Pooling=true"
  }
}
```

### 5.) Apply migrations
```sh
dotnet ef database update
```

### 6.) Run the application
```sh
dotnet run
```
