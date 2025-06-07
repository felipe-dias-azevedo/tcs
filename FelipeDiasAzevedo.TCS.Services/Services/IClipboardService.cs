using FelipeDiasAzevedo.TCS.Business.ViewModels;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public interface IClipboardService
{
    Task<List<ClipboardViewModel>> Get();

    Task<UpsertClipboardViewModel> GetById(string id);

    Task Save(UpsertClipboardViewModel viewModel);

    Task Update(UpsertClipboardViewModel viewModel);

    Task Delete(string id);
}