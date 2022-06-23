using Order.Core.Entities;

namespace Order.Core.Interfaces; 
public interface IBasketRepository {
    Task<Product> AddProduct(string basketId, Product product);
    Task<Product?> DeleteProduct(string basketId, int productId);
    Task<Product> UpdateProduct(string basketId, Product product);

    Task<Product?> GetProduct(string basketId, int productId);
    Task<IEnumerable<Product>> GetProducts(string basketId);
    Task<int> GetProductsCount(string basketId);
}
