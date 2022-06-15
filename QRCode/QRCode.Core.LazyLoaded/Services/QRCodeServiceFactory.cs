using QRCode.Core.Interfaces;
using QRCode.Core.LazyLoaded.Repositories;
using QRCode.Core.Services;

namespace QRCode.Core.LazyLoaded.Services;
public class QRCodeServiceFactory : IQRCodeServiceFactory {
    private readonly IQRCodeRepositoryFactory qRCodeRepositoryFactory;

    public QRCodeServiceFactory(IQRCodeRepositoryFactory qRCodeRepositoryFactory) {
        this.qRCodeRepositoryFactory = qRCodeRepositoryFactory;
    }

    public IQRCodeService Create() {
        IQRCodeRepository qRCodeRepository = qRCodeRepositoryFactory.Create();
        return new QRCodeService(qRCodeRepository);
    }
}
