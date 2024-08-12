using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NK.PasswordStorageApp.BlazorClient;
using NK.PasswordStorageApp.BlazorClient.Services;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:63583/api/") });

builder.Services.AddRadzenComponents();

builder.Services.AddScoped<IToastService, RadzenToastManager>();

await builder.Build().RunAsync();
