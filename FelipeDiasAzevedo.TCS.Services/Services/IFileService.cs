using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface IFileService
{
    ArchiveViewModel ListArchiveDirectories();
    FileArchiveViewModel Archive(string path);
}