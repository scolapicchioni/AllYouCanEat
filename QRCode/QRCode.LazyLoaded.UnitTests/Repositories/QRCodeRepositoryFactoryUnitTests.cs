using Moq;
using QRCode.Core.LazyLoaded.Repositories;
using QRCode.Infrastructure.Repositories;

namespace QRCode.LazyLoaded.UnitTests.Services;
public class QRCodeRepositoryFactoryUnitTests {
    private Mock<IServiceProvider> mockServiceProvider;
    private QRCodeRepositoryFactory sut;
    public QRCodeRepositoryFactoryUnitTests() {
        mockServiceProvider = new();
        sut = new QRCodeRepositoryFactory(mockServiceProvider.Object);
    }
    [Fact]
    public void CanCreateQRCodeRepository() {
        var actual = sut.Create();

        Assert.NotNull(actual);
    }
    [Fact]
    public void CreateReturnsInstanceOfQRCodeRepository() {
        var actual = sut.Create();

        Assert.IsType<QRCodeRepository>(actual);
    }
}
