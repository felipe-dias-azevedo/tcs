using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class LinuxService : IOperationalSystemService
{
    public ServiceStatusViewModel? GetService(string serviceName, bool includeLogs = false)
    {
        throw new NotImplementedException();
    }

    public void Shutdown()
    {
        throw new NotImplementedException();
    }

    public void StartService(string serviceName)
    {
        throw new NotImplementedException();
    }

    public void StopService(string serviceName)
    {
        throw new NotImplementedException();
    }
}