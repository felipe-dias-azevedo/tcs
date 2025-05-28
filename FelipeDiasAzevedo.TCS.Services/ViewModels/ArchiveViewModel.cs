
namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public class ArchiveViewModel
{
    public required List<ArchiveDetailsViewModel> Paths { get; init; }
    public bool? ExistsOnly { get; init; }
}

public class ArchiveDetailsViewModel
{
    public required string FileName { get; init; }
    public required string Path { get; init; }
    public required bool Exists { get; init; }
}
