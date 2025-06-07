using System.ComponentModel.DataAnnotations;

namespace FelipeDiasAzevedo.TCS.Infra.Models.Generic;

public class GenericModel
{
    [Key]
    public required string Id { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; set; }
}
