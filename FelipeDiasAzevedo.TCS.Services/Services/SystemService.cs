using FelipeDiasAzevedo.TCS.Business.ViewModels;
using FelipeDiasAzevedo.TCS.Infra.Options;
using Microsoft.Extensions.Options;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class SystemService(
    IOptions<ServicesOptions> servicesOptions,
    IOperationalSystemService operationalSystem) : ISystemService
{
    private readonly ServicesOptions servicesOptions = servicesOptions.Value;

    public StatusViewModel CheckGeneralStatus()
    {
        var servicesStatus = servicesOptions.Services
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
        operationalSystem.Shutdown();
    }

    public ArchiveViewModel ListArchiveDirectories()
    {
        return new()
        {
            Directories = servicesOptions.ArchiveDirectories
        };
    }
}
