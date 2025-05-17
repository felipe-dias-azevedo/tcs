using System.ComponentModel.DataAnnotations;

namespace FelipeDiasAzevedo.TCS.Infra.Options;

public class ServicesOptions
{
    [Required(AllowEmptyStrings = false)]
    public List<string> Services { get; set; } = [];

    [Required(AllowEmptyStrings = false)]
    public List<string> ArchiveDirectories { get; set; } = [];
}
