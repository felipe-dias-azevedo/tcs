using System.ComponentModel.DataAnnotations;

namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public record UpsertClipboardViewModel
{
    public string? Id { get; set; }

    [Required]
    [MinLength(2)]
    public required string Title { get; init; }

    [Required]
    [MinLength(2)]
    public required string Text { get; init; }
}