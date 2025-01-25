using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MinimalAPIAuth.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services
    .AddScoped(sp => sp
        .GetRequiredService<IHttpClientFactory>()
        .CreateClient("ServerAPI"))
        .AddHttpClient("ServerAPI", (provider, client) =>
        {
            client.BaseAddress = new Uri(builder.Configuration["FrontUrl"]);
        });

await builder.Build().RunAsync();