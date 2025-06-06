using FelipeDiasAzevedo.TCS.Business.ViewModels;
using System.Diagnostics;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class MacService : IOperationalSystemService
{
    public ServiceStatusViewModel? GetService(string serviceName, bool includeLogs = false)
    {
        throw new NotImplementedException();
    }

    public bool IsServiceRunning(string serviceName)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "launchctl",
                Arguments = $"list {serviceName}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        return string.IsNullOrWhiteSpace(error);
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