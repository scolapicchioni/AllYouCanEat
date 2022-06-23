using Order.Core.Entities;

namespace Order.Core.Interfaces;
public interface ICustomerRepository {
    Task<Customer?> GetCustomer();
    Task SaveCustomer(Customer customer);
    Task DeleteCustomer();
}
