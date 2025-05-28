using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface IFileService
{
    ArchiveViewModel ListArchiveDirectories(bool? existsOnly);
    FileArchiveViewModel Archive(string path);
}