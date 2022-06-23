using Order.Core.Entities;
using Order.Core.Interfaces;

namespace Order.Core.Services;
public class BasketService : IBasketService {
    private readonly IBasketRepository repository;

    public BasketService(IBasketRepository repository) => this.repository = repository;
    public Task<Product> GetProduct(string basketId, int productId) => repository.GetProduct(basketId,productId);

    public Task<IEnumerable<Product>> GetProducts(string basketId) => repository.GetProducts(basketId);

    public Task<int> GetProductsCount(string basketId) => repository.GetProductsCount(basketId);

    public async Task<Product> PutInBasket(string basketId, Product product) {
        //Product? found = await repository.GetProduct(basketId, product.Id);
        //if (found is null) {
        //    found = await repository.AddProduct(basketId, product);
        //} else { 
        //    found = await repository.UpdateProduct(basketId, product);
        //}
        //return found;
        return await repository.AddProduct(basketId, product);
    }
}
