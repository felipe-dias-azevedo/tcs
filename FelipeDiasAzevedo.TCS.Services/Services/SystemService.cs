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

    public void StartService()
    {
        throw new NotImplementedException();
    }

    public void StopService()
    {
        throw new NotImplementedException();
    }
}
