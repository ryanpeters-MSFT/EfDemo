using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureAppConfiguration(options =>
{
    options.AddJsonFile("appsettings.json");
});

builder.ConfigureServices((context, services) =>
{
    services.AddTransient<DemoService>();
    services.AddDbContext<DemoContext>((services, options) =>
    {
        var configuration = services.GetService<IConfiguration>();

        var connectionString = configuration.GetConnectionString("Mysql");

        // required specifically for Pomelo Mysql provider
        var version = new MySqlServerVersion(new Version(8, 0));

        options.UseMySql(connectionString, version);
    });
});

var app = builder.Build();

var service = app.Services.GetService<DemoService>();

//await service.SimpleQuery();
await service.Run();