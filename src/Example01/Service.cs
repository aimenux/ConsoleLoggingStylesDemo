using Microsoft.Extensions.Logging;

namespace Example01;

public interface IService
{
    void Run();
}

public class Service : IService
{
    private readonly ILogger<Service> _logger;

    public Service(ILogger<Service> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("Service is running");
    }
}