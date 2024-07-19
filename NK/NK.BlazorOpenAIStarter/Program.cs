using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NK.BlazorOpenAIStarter;
using OpenAI.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var openAIKey = builder.Configuration.GetSection("OpenAIApiKey").Value;

builder.Services.AddOpenAIService(settings => settings.ApiKey = openAIKey);

await builder.Build().RunAsync();
