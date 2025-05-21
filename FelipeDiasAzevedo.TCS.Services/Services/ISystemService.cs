using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface ISystemService
{
    ServiceViewModel CheckGeneralStatus();
    void StartService();
    void StopService();
    void Shutdown();
}
