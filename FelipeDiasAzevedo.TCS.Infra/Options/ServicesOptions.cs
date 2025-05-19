using System.ComponentModel.DataAnnotations;

namespace FelipeDiasAzevedo.TCS.Infra.Options;

public class ServicesOptions
{
    [Required(AllowEmptyStrings = false)]
    public required List<string> Services { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required List<string> ArchiveDirectories { get; set; }
}
