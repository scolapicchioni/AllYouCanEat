using Order.Core.Entities.Basket;

namespace Order.Core.Interfaces; 
public interface IBasketRepository {
    Task<BasketItem> AddBasketItem(string basketId, BasketItem product);
    Task<BasketItem?> DeleteBasketItem(string basketId, int basketItemId);
    Task<BasketItem?> GetBasketItem(string basketId, int baskeItemId);
    Task<IEnumerable<BasketItem>> GetBasketItems(string basketId);
    Task<int> GetBasketItemsCount(string basketId);
    Task UpdateQuantity(string basketId, int basketItemId, int quantity);
}
