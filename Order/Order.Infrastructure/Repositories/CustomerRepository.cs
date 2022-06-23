using Blazored.LocalStorage;
using Order.Core.Entities;
using Order.Core.Interfaces;

namespace Order.Infrastructure.Repositories; 
public class CustomerRepository : ICustomerRepository {
    private readonly ILocalStorageService localStorage;
    private string key = "customer";
    public CustomerRepository(ILocalStorageService localStorage) => this.localStorage = localStorage;

    public async Task SaveCustomer(Customer customer) {
        await localStorage.SetItemAsync(key, customer);
    }

    public async Task DeleteCustomer() {
        await localStorage.RemoveItemAsync(key);
    }

    public async Task<Customer?> GetCustomer() {
        return await localStorage.GetItemAsync<Customer>(key);
    }

}
