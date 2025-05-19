namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public class ArchiveViewModel
{
    public required List<ArchiveDetailsViewModel> Paths { get; init; }
}

public class ArchiveDetailsViewModel
{
    public required string Path { get; init; }
    public required bool Exists { get; init; }
}
