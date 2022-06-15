using QRCode.Core.Interfaces;
using QRCode.Infrastructure.Repositories;

namespace QRCode.Core.LazyLoaded.Repositories;
public class QRCodeRepositoryFactory : IQRCodeRepositoryFactory {
    private readonly IServiceProvider serviceProvider;

    public QRCodeRepositoryFactory(IServiceProvider serviceProvider) {
        this.serviceProvider = serviceProvider;
    }

    public IQRCodeRepository Create() {
        //TODO: ASK FOR HttpClient to talk to real Api, then pass it to the Repository
        //HttpClient http = this.services.GetRequiredService<HttpClient>();
        return new QRCodeRepository(/*http*/);
    }
}
