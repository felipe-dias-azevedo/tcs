using FelipeDiasAzevedo.TCS.Infra.Models.Clipboard;
using FelipeDiasAzevedo.TCS.Infra.Options;
using FelipeDiasAzevedo.TCS.Infra.Repositories.Generic;

namespace FelipeDiasAzevedo.TCS.Infra.Repositories.Clipboard;

public class ClipboardRepository(DatabaseContext context) : GenericRepository<ClipboardModel>(context), IClipboardRepository
{
}
