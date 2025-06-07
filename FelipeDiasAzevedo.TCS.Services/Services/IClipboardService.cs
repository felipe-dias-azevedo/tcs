using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface IClipboardService
{
    Task<List<ClipboardViewModel>> Get();

    Task Save(string text);

    Task Update(string id, string text);

    Task Delete(string id);
}