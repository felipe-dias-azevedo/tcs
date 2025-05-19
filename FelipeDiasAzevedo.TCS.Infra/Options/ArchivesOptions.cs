using System.ComponentModel.DataAnnotations;

namespace FelipeDiasAzevedo.TCS.Infra.Options;

public class ArchivesOptions
{
    [Required(AllowEmptyStrings = false)]
    public required List<string> ArchivePaths { get; set; }
}
