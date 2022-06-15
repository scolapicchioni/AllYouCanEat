using SkiaSharp;
using SkiaSharp.QrCode;
using System.ComponentModel.DataAnnotations;

namespace QRCode.Core.Models;
public class QRCodeModel {
    [Required]
    public string Content { get; set; } = string.Empty;
    [Required]
    [Range(100, 1024)]
    public int Size { get; set; } = 512;
    [Range(0, 10)]
    public int QuietZoneSize { get; set; } = 4;
    public ECCLevel EccLevel { get; set; } = ECCLevel.L;
    public SKColor ClearColor { get; set; } = SKColors.Transparent;
    public SKColor CodeColor { get; set; } = SKColors.Black;
    public SKColor BackgroundColor { get; set; } = SKColors.White;
}
