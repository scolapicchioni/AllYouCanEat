using Order.Core.Entities;

namespace Order.Core.Interfaces;
public interface ICustomerService {
    Task<Customer?> GetCustomer();
    Task SaveCustomer(Customer customer);
    Task DeleteCustomer();
}
