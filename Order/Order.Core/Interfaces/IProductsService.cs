using Order.Core.Entities;

namespace Order.Core.Interfaces;
public interface IProductsService {
    Task<Dictionary<string, List<Product>>> GetAvailableProductsAsync();
    Task<Product?> GetProductById(int productId);
}
