namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface IOperationalSystemService
{
    /// <summary>
    /// Check if OS service is currently running
    /// </summary>
    /// <param name="serviceName"></param>
    /// <returns></returns>
    bool IsServiceRunning(string serviceName);

    /// <summary>
    /// Shutdown Operational System
    /// </summary>
    void Shutdown();
}
