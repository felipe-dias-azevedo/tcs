using FelipeDiasAzevedo.TCS.Business.ViewModels;
using FelipeDiasAzevedo.TCS.Infra.Options;
using Microsoft.Extensions.Options;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class SystemService(
    IOptions<SystemOptions> servicesOptions,
    IOperationalSystemService operationalSystem) : ISystemService
{
    private readonly SystemOptions _systemOptions = servicesOptions.Value;

    public ServiceViewModel GetServices()
    {
        var servicesStatus = _systemOptions.Services
            .Select(service => operationalSystem.GetService(service))
            .Where(service => service is not null)
            .Select(s => s!)
            .ToList();

        return new()
        {
            Services = servicesStatus
        };
    }

    public void Shutdown()
    {
        if (_systemOptions.ShutdownEnabled)
        {
            operationalSystem.Shutdown();
        }
    }

    public ServiceStatusViewModel? GetService(string serviceName, bool includeLogs = false)
    {
        if (!_systemOptions.Services.Contains(serviceName))
        {
            return null;
        }

        return operationalSystem.GetService(serviceName, includeLogs);
    }

    public void StartService(string serviceName)
    {
        if (!_systemOptions.Services.Contains(serviceName))
        {
            return;
        }

        var service = operationalSystem.GetService(serviceName);

        if (service?.CanStart == false)
        {
            return;
        }

        operationalSystem.StartService(serviceName);
    }

    public void StopService(string serviceName)
    {
        if (!_systemOptions.Services.Contains(serviceName))
        {
            return;
        }

        var service = operationalSystem.GetService(serviceName);

        if (service?.CanStop == false)
        {
            return;
        }

        operationalSystem.StopService(serviceName);
    }
}
