using QRCode.Core.Models;
using SkiaSharp;

namespace QRCode.Core.Interfaces;
public interface IQRCodeRepository {
    void RenderQRCodeOnCanvas(QRCodeModel model, SKCanvas canvas);
}
