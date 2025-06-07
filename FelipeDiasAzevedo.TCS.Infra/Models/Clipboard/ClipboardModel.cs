using FelipeDiasAzevedo.TCS.Infra.Models.Generic;

namespace FelipeDiasAzevedo.TCS.Infra.Models.Clipboard;

public class ClipboardModel : GenericModel
{
    public required string Title { get; set; }
    public required string Text { get; set; }
    public required string QrCode { get; set; }
}
