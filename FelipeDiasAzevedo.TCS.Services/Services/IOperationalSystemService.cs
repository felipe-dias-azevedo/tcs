using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface IOperationalSystemService
{
    /// <summary>
    /// Get OS service information, is running, status, etc.
    /// </summary>
    ServiceStatusViewModel? GetService(string serviceName, bool includeLogs = false);

    /// <summary>
    /// Start OS service
    /// </summary>
    void StartService(string serviceName);

    /// <summary>
    /// Stop OS service
    /// </summary>
    void StopService(string serviceName);

    /// <summary>
    /// Shutdown Operational System
    /// </summary>
    void Shutdown();
}
