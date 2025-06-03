using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface ISystemService
{
    ServiceViewModel GetServices();

    ServiceStatusViewModel? GetService(string serviceName, bool includeLogs = false);

    void StartService(string serviceName);

    void StopService(string serviceName);

    void Shutdown();
}
