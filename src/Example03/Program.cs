using System.Text.Json;

using Example03;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var factory = LoggerFactory.Create(loggingBuilder =>
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

try
{
    using var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<ILoggerFactory>(factory);
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddSingleton<IService, Service>();
        })
        .Build();

    var service = host.Services.GetRequiredService<IService>();
    service.Run();
}
catch (Exception ex)
{
    var logger = factory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred");
}