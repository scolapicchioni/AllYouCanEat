using QRCode.Core.Interfaces;

namespace QRCode.Core.LazyLoaded.Repositories;
public interface IQRCodeRepositoryFactory {
    IQRCodeRepository Create();
}