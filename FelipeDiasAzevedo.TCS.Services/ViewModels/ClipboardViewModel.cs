namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public record ClipboardViewModel
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public required string Title { get; init; }

    public required string Text { get; init; }

    public required string QrCode { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime UpdatedAt { get; init; } = DateTime.Now;
}