using Order.Core.Entities.Basket;

namespace Order.Core.Interfaces;
public interface IBasketService {
    Task<BasketItem> PutInBasket(string basketId, BasketItem item);
    Task<BasketItem?> GetBasketItem(string basketId, int basketItemId);
    Task<IEnumerable<BasketItem>> GetBasketItems(string basketId);
    Task<int> GetBasketItemsCount(string basketId);
    Task<BasketItem?> DeleteBasketItem(string basketId, int basketItemId);
    Task UpdateQuantity(string basketId, int basketItemId, int quantity);
}
