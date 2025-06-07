using System.ComponentModel.DataAnnotations;

namespace FelipeDiasAzevedo.TCS.Business.ViewModels;

public record CreateClipboardViewModel
{
    [Required]
    [MinLength(2)]
    public string Title { get; init; }

    [Required]
    [MinLength(2)]
    public string Text { get; init; }
}