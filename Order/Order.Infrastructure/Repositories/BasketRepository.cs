using Order.Core.Entities;
using Order.Core.Interfaces;
using Blazored.LocalStorage;
namespace Order.Infrastructure.Repositories;
public class BasketRepository : IBasketRepository {
    private readonly ILocalStorageService localStorage;

    public BasketRepository(ILocalStorageService localStorage) {
        this.localStorage = localStorage;
    }

    private async Task<HashSet<Product>> getBasket(string basketId) {
        HashSet<Product> basket = await localStorage.GetItemAsync<HashSet<Product>>(basketId);
        if (basket is null) { 
            basket = new HashSet<Product>();
            await localStorage.SetItemAsync(basketId, basket);
        }
        return basket;
    }
    public async Task<Product> AddProduct(string basketId, Product product) {
        HashSet<Product> basket = await getBasket(basketId);
        basket.Add(product);
        await localStorage.SetItemAsync(basketId, basket);
        return product;
    }

    public async Task<Product?> DeleteProduct(string basketId, int productId) {
        HashSet<Product> basket = await getBasket(basketId);
        Product found = basket.FirstOrDefault(x => x.Id == productId);
        if (found is not null) { 
            basket.Remove(found);
            await localStorage.SetItemAsync(basketId, basket);
        }
        return found;
    }

    public async Task<Product?> GetProduct(string basketId, int productId) {
        HashSet<Product> basket = await getBasket(basketId);
        return basket.FirstOrDefault(p => p.Id == productId);
    }

    public async Task<IEnumerable<Product>> GetProducts(string basketId) {
        HashSet<Product> basket = await getBasket(basketId);
        return basket.ToList();
    }

    public async Task<int> GetProductsCount(string basketId) {
        HashSet<Product> basket = await getBasket(basketId);
        return basket.Count();
    }

    public Task<Product> UpdateProduct(string basketId, Product product) {
        return AddProduct(basketId, product);
    }
}
