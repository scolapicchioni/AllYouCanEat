using Order.Core.Entities;

namespace Order.Core.Interfaces;
public interface IBasketService {
    Task<Product> PutInBasket(string basketId, Product product);
    Task<Product> GetProduct(string basketId, int productId);
    Task<IEnumerable<Product>> GetProducts(string basketId);
    Task<int> GetProductsCount(string basketId);
}
