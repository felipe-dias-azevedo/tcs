namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface IOperationalSystemService
{
    /// <summary>
    /// Check if OS service is currently running
    /// </summary>
    bool IsServiceRunning(string serviceName);

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
