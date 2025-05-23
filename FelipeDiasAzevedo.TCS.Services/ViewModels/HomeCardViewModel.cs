namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public record HomeCardViewModel
{
    public required string Header { get; init; }
    public required string Title { get; init; }
    public required string Text { get; init; }

    public required string Controller { get; init; }
    public required string Action { get; init; }
    public required string ButtonText { get; init; }

    public bool Danger { get; init; }
}
