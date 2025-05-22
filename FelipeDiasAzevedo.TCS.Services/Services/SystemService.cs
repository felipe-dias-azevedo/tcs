using FelipeDiasAzevedo.TCS.Business.ViewModels;
using FelipeDiasAzevedo.TCS.Infra.Options;
using Microsoft.Extensions.Options;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class SystemService(
    IOptions<SystemOptions> servicesOptions,
    IOperationalSystemService operationalSystem) : ISystemService
{
    private readonly SystemOptions _systemOptions = servicesOptions.Value;

    public ServiceViewModel CheckGeneralStatus()
    {
        var servicesStatus = _systemOptions.Services
            .Select(svc => new ServiceStatusViewModel
            {
                Name = svc,
                Running = operationalSystem.IsServiceRunning(svc)
            })
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

    public ServiceStatusViewModel? CheckService(string serviceName)
    {
        if (!_systemOptions.Services.Contains(serviceName))
        {
            return null;
        }

        return new()
        {
            Name = serviceName,
            Running = operationalSystem.IsServiceRunning(serviceName)
        };
    }

    public void StartService(string serviceName)
    {
        if (operationalSystem.IsServiceRunning(serviceName))
        {
            return;
        }

        operationalSystem.StartService(serviceName);
    }

    public void StopService(string serviceName)
    {
        if (!operationalSystem.IsServiceRunning(serviceName))
        {
            return;
        }

        operationalSystem.StopService(serviceName);
    }
}
