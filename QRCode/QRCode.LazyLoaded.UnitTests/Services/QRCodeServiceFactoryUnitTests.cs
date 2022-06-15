using Moq;
using QRCode.Core.LazyLoaded.Repositories;
using QRCode.Core.LazyLoaded.Services;
using QRCode.Core.Services;

namespace QRCode.LazyLoaded.UnitTests.Services;
public class QRCodeServiceFactoryUnitTests {
    private Mock<IQRCodeRepositoryFactory> mockRepo;
    private QRCodeServiceFactory sut;
    public QRCodeServiceFactoryUnitTests() {
        mockRepo = new();
        sut = new QRCodeServiceFactory(mockRepo.Object);
    }
    [Fact]
    public void CanCreateQRCodeService() {
        var actual = sut.Create();

        Assert.NotNull(actual);
    }
    [Fact]
    public void CreateReturnsInstanceOfQRCodeService() {
        var actual = sut.Create();

        Assert.IsType<QRCodeService>(actual);
    }
}
