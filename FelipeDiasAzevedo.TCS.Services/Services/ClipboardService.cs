using FelipeDiasAzevedo.TCS.Business.ViewModels;
using FelipeDiasAzevedo.TCS.Infra.Models.Clipboard;
using FelipeDiasAzevedo.TCS.Infra.Repositories.Clipboard;
using QRCoder;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class ClipboardService(IClipboardRepository clipboardRepository) : IClipboardService
{
    public async Task<List<ClipboardViewModel>> Get()
    {
        var models = await clipboardRepository.Get();

        return models.Select(model => new ClipboardViewModel
        {
            Id = model.Id,
            Title = model.Title,
            Text = model.Text,
            QrCode = model.QrCode,
            LastModified = model.UpdatedAt ?? model.CreatedAt
        }).ToList();
    }

    public async Task<UpsertClipboardViewModel> GetById(string id)
    {
        var model = await clipboardRepository.GetById(id);

        if (model is null)
        {
            // TODO: result pattern
            throw new KeyNotFoundException($"Clipboard with ID {id} not found.");
        }

        return new UpsertClipboardViewModel
        {
            Id = model.Id,
            Title = model.Title,
            Text = model.Text,
        };
    }

    public async Task Save(UpsertClipboardViewModel viewModel)
    {
        var clipboard = new ClipboardModel
        {
            Id = Guid.NewGuid().ToString(),
            Title = viewModel.Title,
            Text = viewModel.Text,
            QrCode = GenerateQrCode(viewModel.Text),
            CreatedAt = DateTime.Now
        };

        await clipboardRepository.Insert(clipboard);
    }

    public async Task Update(UpsertClipboardViewModel viewModel)
    {
        if (viewModel.Id is null)
        {
            // TODO: result pattern
            throw new ArgumentNullException(nameof(viewModel.Id), "Clipboard ID cannot be null.");
        }

        var clipboard = await clipboardRepository.GetById(viewModel.Id);

        if (clipboard is null)
        {
            // TODO: result pattern
            throw new KeyNotFoundException($"Clipboard with ID {viewModel.Id} not found.");
        }

        clipboard.Title = viewModel.Title;
        clipboard.Text = viewModel.Text;
        clipboard.QrCode = GenerateQrCode(viewModel.Text);
        clipboard.UpdatedAt = DateTime.Now;

        await clipboardRepository.Update(clipboard);
    }

    public async Task Delete(string id)
    {
        var clipboard = await clipboardRepository.GetById(id);

        if (clipboard is null)
        {
            // TODO: result pattern
            throw new KeyNotFoundException($"Clipboard with ID {id} not found.");
        }

        await clipboardRepository.Remove(clipboard);
    }

    private string GenerateQrCode(string text)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new Base64QRCode(qrCodeData);
        var base64 = qrCode.GetGraphic(20);

        return $"data:image/png;base64,{base64}";
    }
}
