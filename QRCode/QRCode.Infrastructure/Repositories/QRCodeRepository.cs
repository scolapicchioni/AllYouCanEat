using QRCode.Core.Interfaces;
using QRCode.Core.Models;
using SkiaSharp;
using SkiaSharp.QrCode;

namespace QRCode.Infrastructure.Repositories;
public class QRCodeRepository : IQRCodeRepository {
    public void RenderQRCodeOnCanvas(QRCodeModel model, SKCanvas canvas) {

        using var generator = new QRCodeGenerator();

        // Generate QrCode
        var qr = generator.CreateQrCode(model.Content, model.EccLevel, quietZoneSize: model.QuietZoneSize);

        // Render to canvas
        var info = new SKImageInfo(model.Size, model.Size); // Make sure match with SKCanvasView width & height.

        canvas.Render(qr, info.Width, info.Height, model.ClearColor, model.CodeColor, model.BackgroundColor);
    }
}
