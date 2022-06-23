using Order.Core.Entities;

namespace Order.Core.Interfaces;
public interface IProductsRepository {
    Task<Dictionary<string,List<Product>>> GetAvailableProductsAsync();
}
