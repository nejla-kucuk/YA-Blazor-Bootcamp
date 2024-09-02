using Microsoft.Extensions.Options;
using NK.ChatGPTClone.Application;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Infrastructure;
using NK.ChatGPTClone.WebApi;
using NK.ChatGPTClone.WebApi.Filters;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Warning()
    .CreateLogger();

try
{
    Log.Warning("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog();

    // Add services to the container.

    // Controller'lar� servis olarak ekle
    builder.Services.AddControllers(opt =>
    {
        // Global exception filtresini ekle
        opt.Filters.Add<GlobalExceptionFilter>();
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

    builder.Services.AddApplication();

    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddWebApi(builder.Configuration);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    var requestLocalizationOptions = app.Services
        .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;

    app.UseRequestLocalization(requestLocalizationOptions);

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}



