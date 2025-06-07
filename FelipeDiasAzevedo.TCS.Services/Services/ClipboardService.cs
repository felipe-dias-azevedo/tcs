using FelipeDiasAzevedo.TCS.Business.ViewModels;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FelipeDiasAzevedo.TCS.Business.Services;

public class ClipboardService : IClipboardService
{
    public async Task<List<ClipboardViewModel>> Get()
    {
        await Task.Delay(150);
        return
        [
            new()
            {
                Title = "Google",
                Text = "https://www.google.com/",
                QrCode = GenerateQrCode("https://www.google.com/")
            },
            new()
            {
                Title = "Google",
                Text = "https://www.google.com/",
                QrCode = GenerateQrCode("https://www.google.com/")
            },
            new()
            {
                Title = "Mercado Livre",
                Text = "https://produto.mercadolivre.com.br/MLB-4035715673-kit-pintura-diamante-amendoeiras-diamond-art-_JM?vip_filters=shipping%3Afulfillment&highlight=false&headerTopBrand=false#polycard_client=search-nordic&position=3&search_layout=grid&type=item&tracking_id=0b9138e6-241c-412d-b9d5-a116e35a9108&wid=MLB4035715673&sid=search",
                QrCode = GenerateQrCode("https://produto.mercadolivre.com.br/MLB-4035715673-kit-pintura-diamante-amendoeiras-diamond-art-_JM?vip_filters=shipping%3Afulfillment&highlight=false&headerTopBrand=false#polycard_client=search-nordic&position=3&search_layout=grid&type=item&tracking_id=0b9138e6-241c-412d-b9d5-a116e35a9108&wid=MLB4035715673&sid=search")
            }
        ];
    }

    public Task Save(string text)
    {
        throw new NotImplementedException();
    }

    public Task Update(string id, string text)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
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
