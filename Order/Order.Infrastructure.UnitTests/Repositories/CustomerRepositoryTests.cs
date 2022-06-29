using Blazored.LocalStorage;
using Moq;
using Order.Core.Entities;

using Order.Infrastructure.Repositories;
namespace Order.Infrastructure.UnitTests.Repositories;
public class CustomerRepositoryTests {
    Mock<ILocalStorageService> localStorageServiceMock;
    CustomerRepository sut;
    string key;
    public CustomerRepositoryTests() {
        localStorageServiceMock = new();
        key = "customer";
        sut = new(localStorageServiceMock.Object);
    }

    [Fact]
    public async Task SaveCustomer_ShouldSetCustomerInLocalStorage() {
        Customer customer = new Customer();

        await sut.SaveCustomer(customer);

        localStorageServiceMock.Verify(ls => ls.SetItemAsync(key, customer, default));
    }

    [Fact]
    public async Task DeleteCustomer_ShouldRemoveCustomerFromLocalStorage() {
        Customer customer = new Customer();

        await sut.DeleteCustomer();

        localStorageServiceMock.Verify(ls => ls.RemoveItemAsync(key, default));
    }

    [Fact]
    public async Task GetCustomer_ShouldReturnCustomerFromLocalStorage_WhenCustomerExists() {
        Customer expected = new Customer() { Name = "Customer1", Room = "V1", Note = "Note1"};

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<Customer>(key, default)).ReturnsAsync(expected);

        Customer? actual = await sut.GetCustomer();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetCustomer_ShouldReturnNull_WhenCustomerDoesNotExist() {
        localStorageServiceMock.Setup(ls => ls.GetItemAsync<Customer>(key, default)).ReturnsAsync(default(Customer));

        Customer? actual = await sut.GetCustomer();

        Assert.Null(actual);
    }
}
