using QRCode.Core.Interfaces;

namespace QRCode.Core.LazyLoaded.Services; 
public interface IQRCodeServiceFactory {
    IQRCodeService Create();
}