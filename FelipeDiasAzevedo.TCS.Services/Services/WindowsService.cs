using System.Diagnostics;
using System.ServiceProcess;

namespace FelipeDiasAzevedo.TCS.Business.Services;

#pragma warning disable CA1416

public class WindowsService : IOperationalSystemService
{
    public void Shutdown()
    {
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

        return sc.Status is ServiceControllerStatus.Running;
    }

    public void StartService(string serviceName)
    {
        var sc = new ServiceController(serviceName);

        if (sc.Status is ServiceControllerStatus.Stopped)
        {
            sc.Start();
        }
        else if (sc.Status is ServiceControllerStatus.Paused)
        {
            sc.Continue();
        }
    }

    public void StopService(string serviceName)
    {
        var sc = new ServiceController(serviceName);

        if (sc.Status is ServiceControllerStatus.Running or ServiceControllerStatus.Paused)
        {
            sc.Stop();
        }
    }
}

#pragma warning restore CA1416
