using System.ComponentModel.DataAnnotations;

namespace FelipeDiasAzevedo.TCS.Infra.Options;

public class SystemOptions
{
    [Required(AllowEmptyStrings = false)]
    public required List<string> Services { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required bool ShutdownEnabled { get; set; }
}
