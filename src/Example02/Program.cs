using System.Text.Json;

using Example02;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();

            loggingBuilder.AddJsonConsole(options =>
            {
                options.JsonWriterOptions = new JsonWriterOptions
                {
                    Indented = true
                };
            });
        });
        
        services.AddSingleton<IService, Service>();
    })
    .Build();
    
var service = host.Services.GetRequiredService<IService>();
service.Run();