using Order.Core.Interfaces;
using Blazored.LocalStorage;
using Order.Core.Entities.Basket;

namespace Order.Infrastructure.Repositories;
public class BasketRepository : IBasketRepository {
    private readonly ILocalStorageService localStorage;

    public BasketRepository(ILocalStorageService localStorage) {
        this.localStorage = localStorage;
    }

    internal async Task<HashSet<BasketItem>> GetBasket(string basketId) {
        HashSet<BasketItem> basket = await localStorage.GetItemAsync<HashSet<BasketItem>>(basketId);
        if (basket is null) { 
            basket = new HashSet<BasketItem>();
            await localStorage.SetItemAsync(basketId, basket);
        }
        return basket;
    }
    public async Task<BasketItem> UpsertBasketItem(string basketId, BasketItem basketItem) {
        HashSet<BasketItem> basket = await GetBasket(basketId);
        if (basketItem.Id == 0) {
            basketItem.Id = basket.Count() == 0 ? 1 : basket.Max(bi => bi.Id) + 1;
        }

        BasketItem? itemToReplace = basket.FirstOrDefault(bi => bi.Id == basketItem.Id);
        if (itemToReplace is not null) {
            basket.Remove(itemToReplace);
        }
        basket.Add(basketItem);
        
        await localStorage.SetItemAsync(basketId, basket);
        return basketItem;
    }

    public async Task<BasketItem?> DeleteBasketItem(string basketId, int basketItemId) {
        HashSet<BasketItem> basket = await GetBasket(basketId);
        BasketItem? found = basket.FirstOrDefault(i => i.Id == basketItemId); 
        if (found is not null) { 
            basket.Remove(found);
            await localStorage.SetItemAsync(basketId, basket);
        }
        return found;
    }

    public async Task<BasketItem?> GetBasketItem(string basketId, int basketItemId) {
        HashSet<BasketItem> basket = await GetBasket(basketId);
        return basket.FirstOrDefault(p => p.Id == basketItemId);
    }

    public async Task<IEnumerable<BasketItem>> GetBasketItems(string basketId) {
        HashSet<BasketItem> basket = await GetBasket(basketId);
        return basket.ToList();
    }

    public async Task<int> GetBasketItemsCount(string basketId) {
        HashSet<BasketItem> basket = await GetBasket(basketId);
        return basket.Count();
    }

    public async Task UpdateQuantity(string basketId, int basketItemId, int quantity) {
        HashSet<BasketItem> basket = await GetBasket(basketId);

        BasketItem existing = basket.First(i => i.Id == basketItemId); 
        if (existing is not null) {
            if (quantity <= 0) {
                basket.Remove(existing);
            } else {
                existing.Quantity = quantity;
            }
        }

        await localStorage.SetItemAsync(basketId, basket);
        
    }
}
