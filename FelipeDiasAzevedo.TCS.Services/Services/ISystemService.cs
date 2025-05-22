using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface ISystemService
{
    ServiceViewModel CheckGeneralStatus();

    ServiceStatusViewModel? CheckService(string serviceName);

    void StartService(string serviceName);

    void StopService(string serviceName);

    void Shutdown();
}
