﻿using QRCode.Core.Models;
using QRCode.Infrastructure.Repositories;
using SkiaSharp;
namespace QRCode.Infrastructure.UnitTests.Repositories;
public class QRCodeRepositoryUnitTests {
    [Fact]
    public void ShouldDrawOnCanvas() {
        byte[]? expected = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 100, 0, 0, 0, 100, 8, 6, 0, 0, 0, 112, 226, 149, 84, 0, 0, 0, 4, 115, 66, 73, 84, 8, 8, 8, 8, 124, 8, 100, 136, 0, 0, 2, 35, 73, 68, 65, 84, 120, 156, 237, 157, 75, 110, 197, 32, 12, 0, 155, 170, 247, 191, 114, 186, 205, 123, 85, 41, 88, 182, 24, 211, 153, 117, 66, 136, 70, 54, 132, 95, 174, 251, 190, 239, 15, 193, 240, 185, 187, 2, 242, 138, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 198, 87, 244, 198, 235, 186, 50, 235, 241, 131, 209, 32, 244, 243, 217, 239, 215, 141, 234, 245, 188, 118, 103, 253, 71, 24, 33, 48, 20, 2, 35, 156, 178, 158, 100, 204, 113, 141, 82, 72, 52, 189, 172, 212, 171, 250, 29, 102, 49, 66, 96, 40, 4, 134, 66, 96, 164, 180, 33, 239, 204, 230, 210, 138, 245, 21, 163, 174, 237, 236, 243, 118, 214, 223, 8, 129, 161, 16, 24, 37, 41, 43, 155, 149, 175, 241, 209, 87, 124, 7, 140, 16, 24, 10, 129, 161, 16, 24, 45, 218, 144, 149, 238, 107, 70, 183, 119, 39, 70, 8, 12, 133, 192, 40, 73, 89, 59, 83, 67, 198, 136, 235, 206, 250, 27, 33, 48, 20, 2, 35, 37, 101, 85, 207, 79, 175, 60, 59, 58, 111, 190, 243, 29, 158, 24, 33, 48, 20, 2, 67, 33, 48, 174, 14, 187, 112, 179, 242, 123, 131, 87, 53, 66, 104, 40, 4, 70, 201, 82, 210, 200, 0, 223, 108, 121, 171, 215, 254, 70, 116, 222, 60, 227, 217, 35, 140, 16, 24, 10, 129, 161, 16, 24, 37, 107, 123, 35, 11, 13, 102, 183, 31, 172, 220, 183, 66, 118, 61, 221, 142, 112, 8, 10, 129, 17, 78, 89, 25, 163, 170, 209, 50, 50, 186, 182, 209, 50, 170, 231, 236, 141, 16, 24, 10, 129, 161, 16, 24, 229, 139, 28, 50, 134, 40, 86, 134, 47, 70, 101, 70, 152, 93, 3, 150, 133, 17, 2, 67, 33, 48, 82, 70, 123, 163, 41, 101, 116, 79, 197, 23, 254, 108, 151, 117, 246, 139, 187, 98, 4, 193, 8, 129, 161, 16, 24, 10, 129, 209, 114, 145, 67, 197, 136, 235, 206, 157, 183, 79, 140, 16, 24, 10, 129, 209, 254, 188, 172, 232, 125, 209, 93, 88, 179, 221, 125, 187, 189, 135, 160, 16, 24, 10, 129, 209, 226, 0, 179, 149, 246, 36, 163, 109, 139, 214, 197, 25, 195, 3, 81, 8, 140, 246, 231, 101, 69, 187, 158, 21, 107, 123, 71, 247, 205, 98, 132, 192, 80, 8, 140, 227, 206, 58, 153, 37, 123, 219, 66, 22, 70, 8, 12, 133, 192, 80, 8, 140, 22, 109, 72, 214, 31, 16, 34, 237, 70, 197, 36, 215, 8, 35, 4, 134, 66, 96, 180, 56, 47, 43, 107, 205, 86, 245, 238, 93, 7, 23, 15, 68, 33, 48, 20, 2, 163, 229, 1, 102, 25, 63, 5, 139, 60, 43, 163, 188, 191, 48, 66, 96, 40, 4, 70, 139, 165, 164, 255, 9, 35, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 134, 66, 96, 40, 4, 198, 55, 144, 253, 12, 207, 54, 167, 39, 20, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
        SKImageInfo info = new SKImageInfo(100, 100);
        using SKSurface? surface = SKSurface.Create(info);
        SKCanvas? canvas = surface.Canvas;
        
        QRCodeModel model = new QRCodeModel() { Content = "123456", Size=100};
        QRCodeRepository sut = new QRCodeRepository();
        sut.RenderQRCodeOnCanvas(model, canvas);

        using SKImage? image = surface.Snapshot();
        using SKData? data = image.Encode(SKEncodedImageFormat.Png, 100);

        byte[]? actual = data.ToArray();

        Assert.Equal(expected,actual);
    }
}
