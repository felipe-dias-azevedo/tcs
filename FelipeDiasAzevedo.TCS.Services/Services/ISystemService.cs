using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface ISystemService
{
    StatusViewModel CheckGeneralStatus();

    void Shutdown();
}
