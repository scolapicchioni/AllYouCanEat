using Moq;
using QRCode.Core.Interfaces;
using QRCode.Core.Models;
using QRCode.Core.Services;
using SkiaSharp;

namespace QRCode.Core.UnitTests.Services;
public class QRCodeServiceUnitTests {
    [Fact]
    public void RenderOnCanvasShouldInvokeRepositoryMethodWithSameParameters() {
        Mock<IQRCodeRepository> mockRepo = new Mock<IQRCodeRepository>();
        SKCanvas canvas = new SKCanvas(new SKBitmap());
        QRCodeModel model = new QRCodeModel();

        QRCodeService sut = new QRCodeService(mockRepo.Object);

        sut.RenderQRCodeOnCanvas(model, canvas);

        mockRepo.Verify(r=>r.RenderQRCodeOnCanvas(model,canvas));
    }
}
