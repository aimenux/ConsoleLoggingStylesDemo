using System.Text.Json;

using Example01;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging((_, loggingBuilder) =>
    {
        loggingBuilder.ClearProviders();
        
        loggingBuilder.AddJsonConsole(options =>
        {
            options.JsonWriterOptions = new JsonWriterOptions
            {
                Indented = true
            };
        });
    })
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<IService, Service>();
    })
    .Build();
    
var service = host.Services.GetRequiredService<IService>();
service.Run();
    