# Logging.Serilog

| View       | Badge                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|:-----------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Prerelease | [![Expensely.Logging.Serilog package in expensely-au@Prerelease feed in Azure Artifacts](https://feeds.dev.azure.com/expensely-au/_apis/public/Packaging/Feeds/4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1@0b477f7e-e363-4441-97f7-bf3189253564/Packages/0205fb37-f302-495e-bf20-2038bcb1c5e1/Badge)](https://dev.azure.com/expensely-au/Expensely/_packaging?_a=package&feed=4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1%400b477f7e-e363-4441-97f7-bf3189253564&package=0205fb37-f302-495e-bf20-2038bcb1c5e1&preferRelease=true) |
| Release    | [![Expensely.Logging.Serilog package in expensely-au@Release feed in Azure Artifacts](https://feeds.dev.azure.com/expensely-au/_apis/public/Packaging/Feeds/4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1@f9bccf78-9a6f-4e24-bcd7-b5f77186974c/Packages/0205fb37-f302-495e-bf20-2038bcb1c5e1/Badge)](https://dev.azure.com/expensely-au/Expensely/_packaging?_a=package&feed=4634f7ff-ee1a-49bd-b3de-2f19eb18d3e1%40f9bccf78-9a6f-4e24-bcd7-b5f77186974c&package=0205fb37-f302-495e-bf20-2038bcb1c5e1&preferRelease=true)    |


## How to Use  
### Configuration  
| Property Name | Description                                                                                                                  |
|:--------------|:-----------------------------------------------------------------------------------------------------------------------------|
| Serilog       | Serilog config please go [here](https://github.com/serilog/serilog-settings-configuration/blob/master/README.md) for details |

Add Configuration
``` json
{
  "Serilog": {
    "MinimumLevel": "Warning",
    "Override": {
      "Microsoft.AspNetCore": "Warning",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Warning",
      "Microsoft.EntityFrameworkCore": "Debug"
    }
  }
}
```

Add Serilog to `IHostBuilder`
``` csharp
public void ConfigureServices(IServiceCollection services)
{
    IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services => { services.AddHostedService<Worker>(); })
        .AddSerilog()
        .Build();
    ...
}
```

Add Serilog to `WebApplicationBuilder`
``` csharp
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddSerilog();
```

## Development
### Build, Package & Release
#### Locally
```
// Step 1: Authenticate
dotnet build --configuration release 

// Step 2: Pack
dotnet pack --configuration release 

// Step 3: Publish
dotnet nuget push "Logging.Serilog.*.nupkg" -Source "github"
```


