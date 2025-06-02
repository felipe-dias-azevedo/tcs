using FelipeDiasAzevedo.TCS.Business.ViewModels;
using FelipeDiasAzevedo.TCS.Infra.Options;
using Microsoft.Extensions.Options;
using System.IO.Compression;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class FileService(IOptions<ArchivesOptions> archivesOptions) : IFileService
{
    private readonly ArchivesOptions _archivesOptions = archivesOptions.Value;

    public ArchiveViewModel ListArchiveDirectories(bool? existsOnly)
    {
        var paths = _archivesOptions.ArchivePaths
            .Select(x => new ArchiveDetailsViewModel
            {
                FileName = GetFileName(x),
                Path = x,
                Exists = Exists(x)
            })
            .Where(x => !existsOnly.HasValue || !existsOnly.Value || x.Exists)
            .ToList();

        return new()
        {
            Paths = paths,
            ExistsOnly = existsOnly
        };
    }

    public FileArchiveViewModel Archive(string path)
    {
        if (!_archivesOptions.ArchivePaths.Contains(path) || !Exists(path))
        {
            throw new InvalidOperationException("Archive path does not exist");
        }

        var fileName = Path.GetFileName(path);

        // TODO: check if can get content of file/folder if service is locking it

        if (File.Exists(path))
        {
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            return new()
            {
                Stream = stream,
                ContentType = "application/octet-stream",
                FileName = fileName
            };
        }
        else if (Directory.Exists(path))
        {
            var zipStream = new MemoryStream();
            ZipFile.CreateFromDirectory(path, zipStream, CompressionLevel.Fastest, includeBaseDirectory: true);

            zipStream.Position = 0;

            return new()
            {
                Stream = zipStream,
                ContentType = "application/zip",
                FileName = $"{fileName}.zip"
            };
        }

        throw new InvalidOperationException("Invalid type for path.");
    }

    private static bool Exists(string path)
    {
        return File.Exists(path) || Directory.Exists(path);
    }

    private static string GetFileName(string path)
    {
        var fileInfo = new FileInfo(path);

        return fileInfo.Name;
    }
}
