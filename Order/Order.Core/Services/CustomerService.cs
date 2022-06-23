using Order.Core.Entities;
using Order.Core.Interfaces;

namespace Order.Core.Services;
public class CustomerService : ICustomerService {
    private readonly ICustomerRepository repository;

    public CustomerService(ICustomerRepository repository) => this.repository = repository;
    public Task SaveCustomer(Customer customer) => repository.SaveCustomer(customer);

    public Task DeleteCustomer() => repository.DeleteCustomer();

    public Task<Customer?> GetCustomer() => repository.GetCustomer();

}
