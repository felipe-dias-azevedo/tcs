using FelipeDiasAzevedo.TCS.Business.ViewModels;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;

namespace FelipeDiasAzevedo.TCS.Business.Services;

#pragma warning disable CA1416

public class WindowsService : IOperationalSystemService
{
    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(30);

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

    public List<ServiceLogViewModel> GetLogs(string serviceName)
    {
        using var eventLog = new EventLog("System");

        return eventLog.Entries
            .Cast<EventLogEntry>()
            .Reverse()
            .Where(entry =>
                (entry.Source == "Service Control Manager" || entry.Source == serviceName) &&
                entry.Message.Contains(serviceName, StringComparison.OrdinalIgnoreCase))
            .Take(10)
            .Select(entry => new ServiceLogViewModel
            {
                DateTime = entry.TimeGenerated,
                Type = entry.EntryType.ToString(),
                Message = entry.Message
            })
            .ToList();
    }

    public ServiceStatusViewModel? GetService(string serviceName, bool includeLogs = false)
    {
        var logs = new List<ServiceLogViewModel>();

        try
        {
            var service = new ServiceController(serviceName);

            var status = service.Status switch
            {
                ServiceControllerStatus.Stopped => ServiceStatus.Stopped,
                ServiceControllerStatus.Running => ServiceStatus.Running,
                ServiceControllerStatus.Paused => ServiceStatus.Paused,
                ServiceControllerStatus.ContinuePending or
                ServiceControllerStatus.PausePending or
                ServiceControllerStatus.StartPending or
                ServiceControllerStatus.StopPending => ServiceStatus.Pending,
            };

            if (includeLogs)
            {
                logs = GetLogs(serviceName);
            }

            return new()
            {
                Name = serviceName,
                DisplayName = service.DisplayName,
                ServiceType = service.ServiceType.ToString(),
                StartType = service.StartType.ToString(),
                Status = status,
                Logs = logs
            };
        }
        catch (InvalidOperationException ex) when (ex.InnerException is Win32Exception)
        {
            return null;
        }
        catch
        {
            // TODO: Add logs
            return null;
        }
    }

    public void StartService(string serviceName)
    {
        var sc = new ServiceController(serviceName);

        if (sc.Status is ServiceControllerStatus.Stopped)
        {
            sc.Start();
            sc.WaitForStatus(ServiceControllerStatus.Running, _timeout);
        }
        else if (sc.Status is ServiceControllerStatus.Paused)
        {
            sc.Continue();
            sc.WaitForStatus(ServiceControllerStatus.Running, _timeout);
        }
    }

    public void StopService(string serviceName)
    {
        var sc = new ServiceController(serviceName);

        if (sc.Status is ServiceControllerStatus.Running or ServiceControllerStatus.Paused)
        {
            sc.Stop();
            sc.WaitForStatus(ServiceControllerStatus.Stopped, _timeout);
        }
    }
}

#pragma warning restore CA1416
