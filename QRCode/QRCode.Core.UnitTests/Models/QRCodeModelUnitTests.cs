using QRCode.Core.Models;
using SkiaSharp;
using SkiaSharp.QrCode;

namespace QRCode.Core.UnitTests.Models;
public class QRCodeModelUnitTests {
    QRCodeModel sut;
    public QRCodeModelUnitTests() {
        sut = new ();
    }
    [Fact]
    public void DefaultContentShouldBeEmpty() {
        Assert.Equal(string.Empty, sut.Content);
    }
    [Fact]
    public void DefaultSizeShouldBe512() {
        Assert.Equal(512, sut.Size);
    }
    [Fact]
    public void DefaultQuietZoneSizeShouldBe4() {
        Assert.Equal(4, sut.QuietZoneSize);
    }
    [Fact]
    public void DefaultEccLevelShouldBeL() {
        Assert.Equal(ECCLevel.L, sut.EccLevel);
    }
    [Fact]
    public void DefaultClearColorShouldBeTransparent() {
        Assert.Equal(SKColors.Transparent, sut.ClearColor);
    }
    [Fact]
    public void DefaultCodeColorShouldBeBlack() {
        Assert.Equal(SKColors.Black, sut.CodeColor);
    }
    [Fact]
    public void DefaultBackgroundColorShouldBeWhite() {
        Assert.Equal(SKColors.White, sut.BackgroundColor);
    }
}
