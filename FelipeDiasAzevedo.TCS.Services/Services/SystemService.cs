using System.IO.Compression;
using FelipeDiasAzevedo.TCS.Business.ViewModels;
using FelipeDiasAzevedo.TCS.Infra.Options;
using Microsoft.Extensions.Options;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class SystemService(
    IOptions<ServicesOptions> servicesOptions,
    IOperationalSystemService operationalSystem) : ISystemService
{
    private readonly ServicesOptions servicesOptions = servicesOptions.Value;

    public StatusViewModel CheckGeneralStatus()
    {
        var servicesStatus = servicesOptions.Services
            .Select(svc => new ServiceStatusViewModel
            {
                Name = svc,
                Running = operationalSystem.IsServiceRunning(svc)
            })
            .ToList();

        return new()
        {
            Services = servicesStatus
        };
    }

    public void Shutdown()
    {
        operationalSystem.Shutdown();
    }

    public ArchiveViewModel ListArchiveDirectories()
    {
        return new()
        {
            Directories = servicesOptions.ArchiveDirectories
        };
    }

    public FileArchiveViewModel Archive(string path)
    {
        // TODO: check if path contains in options

        if (File.Exists(path))
        {
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var contentType = "application/octet-stream";
            var fileName = Path.GetFileName(path);

            return new()
            {
                Stream = stream,
                ContentType = contentType,
                FileName = fileName
            };
        }
        else if (Directory.Exists(path))
        {
            var zipStream = new MemoryStream();
            ZipFile.CreateFromDirectory(path, zipStream);

            return new()
            {
                Stream = zipStream,
                ContentType = "application/zip",
                FileName = $"{Path.GetFileName(path)}.zip"
            };
        }

        throw new InvalidOperationException("Invalid type for path.");
    }
}
