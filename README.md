# Protected Minimal API with Individual Accounts

This is a basic project in `NET8` and `Blazor` with minimal APIs protected by *Individual Accounts*. Create a new project and the authentication has to be with *Individual Accounts*.

### Before starting

Remember to run from the _Package Manager Console_ the command:

```powershell
update-database
```

in order to create the tables for the *Microsoft Identity*.

## Configuration

### Server

The URL for the platform is saved in the _appconfig.json_ like

```json
{
    "ConnectionStrings": {
        "DefaultConnection": ""
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "DetailedErrors": true,
    "FrontUrl": "https://localhost:7202"
}
```

In the server _Program.cs_ add the following lines (*ServerAPI* is an arbitrary name, you can choose a different one):

```csharp
builder.Services
    .AddScoped(sp => sp
        .GetRequiredService<IHttpClientFactory>()
        .CreateClient("ServerAPI"))
        .AddHttpClient("ServerAPI", (provider, client) =>
        {
            client.BaseAddress = new Uri(builder.Configuration["FrontUrl"]);
        });
```

those lines must be before

```csharp
var app = builder.Build();
```

### Client

In the _appconfig.json_ for the client project, I added a new value for the URL (the URL is the same as the server configuration):

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "FrontUrl": "https://localhost:7202"
}
```

Then, in the _Program.cs_ I added those lines (I used the save ServerAPI as before):

```csharp
builder.Services
    .AddScoped(sp => sp
        .GetRequiredService<IHttpClientFactory>()
        .CreateClient("ServerAPI"))
        .AddHttpClient("ServerAPI", (provider, client) =>
        {
            client.BaseAddress = new Uri(builder.Configuration["FrontUrl"]);
        });
```
