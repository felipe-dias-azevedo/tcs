using System.Diagnostics;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class MacService : IOperationalSystemService
{
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
}