using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NK.BlazorGiftSuggestionApp;
using OpenAI.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var openAIKey = builder
                .Configuration
                .GetSection("OpenAIApiKey")
                .Value;

builder.Services.AddOpenAIService(settings => settings.ApiKey = openAIKey);

builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
