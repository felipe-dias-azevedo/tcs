using System.Diagnostics;
using System.ServiceProcess;

namespace FelipeDiasAzevedo.TCS.Business.Services;

#pragma warning disable CA1416 // Validar a compatibilidade da plataforma

public class WindowsService : IOperationalSystemService
{
    public void Shutdown()
    {
        return;

        // Execute the shutdown command using Process.Start
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "shutdown",
            Arguments = "/s /f /t 0",  // /s: shutdown, /f: force close apps, /t 0: zero-second delay
            CreateNoWindow = true,
            UseShellExecute = false
        };

        // Start the process to shutdown
        Process.Start(processStartInfo);
    }

    public bool IsServiceRunning(string serviceName)
    {
        var sc = new ServiceController(serviceName);

        return sc.Status == ServiceControllerStatus.Running;
    }
}

#pragma warning restore CA1416 // Validar a compatibilidade da plataforma
