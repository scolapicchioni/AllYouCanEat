using Order.Core.Entities;
using Order.Core.Interfaces;

namespace Order.Core.Services;
public class ProductsService : IProductsService {
    private readonly IProductsRepository repository;

    public ProductsService(IProductsRepository repository) {
        this.repository = repository;
    }
    public Task<Dictionary<string,List<Product>>> GetAvailableProductsAsync() {
        return repository.GetAvailableProductsAsync();
    }

    public Task<Product?> GetProductById(int productId) => repository.GetProductById(productId);
}
