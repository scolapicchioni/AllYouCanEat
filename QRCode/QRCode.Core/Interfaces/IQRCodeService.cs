using QRCode.Core.Models;
using SkiaSharp;

namespace QRCode.Core.Interfaces;
public interface IQRCodeService {
    void RenderQRCodeOnCanvas(QRCodeModel model, SKCanvas canvas);
}
