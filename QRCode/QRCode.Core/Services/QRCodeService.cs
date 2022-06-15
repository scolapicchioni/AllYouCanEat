using QRCode.Core.Interfaces;
using QRCode.Core.Models;
using SkiaSharp;

namespace QRCode.Core.Services;
public class QRCodeService : IQRCodeService {
    private readonly IQRCodeRepository repository;

    public QRCodeService(IQRCodeRepository repository) {
        this.repository = repository;
    }
    public void RenderQRCodeOnCanvas(QRCodeModel model, SKCanvas canvas) {
        repository.RenderQRCodeOnCanvas(model, canvas);
    }
}
