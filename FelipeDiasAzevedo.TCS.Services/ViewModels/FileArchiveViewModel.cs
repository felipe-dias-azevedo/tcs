
namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public class FileArchiveViewModel
{
    public required Stream Stream { get; init; }
    public required string ContentType { get; init; }
    public required string FileName { get; init; }
}