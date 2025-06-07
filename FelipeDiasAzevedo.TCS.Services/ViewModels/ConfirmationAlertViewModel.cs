namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public record ConfirmationAlertViewModel
{
    public required string Header { get; init; }
    public required string Body { get; init; }
    public required string Button { get; init; }
    public required string Action { get; init; }
    public required string Controller { get; init; }
    public required string Icon { get; init; }
    public required string Color { get; init; }

    public Dictionary<string, string> Routes { get; init; } = [];
}
