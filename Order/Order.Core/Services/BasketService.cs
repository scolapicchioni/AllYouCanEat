﻿using Order.Core.Entities.Basket;
using Order.Core.Interfaces;

namespace Order.Core.Services;
public class BasketService : IBasketService {
    private readonly IBasketRepository repository;

    public BasketService(IBasketRepository repository) => this.repository = repository;

    public Task<BasketItem?> DeleteBasketItem(string basketId, int basketItemId) => repository.DeleteBasketItem(basketId, basketItemId);

    public Task<BasketItem> GetBasketItem(string basketId, int productId) => repository.GetBasketItem(basketId,productId);

    public Task<IEnumerable<BasketItem>> GetBasketItems(string basketId) => repository.GetBasketItems(basketId);

    public Task<int> GetBasketItemsCount(string basketId) => repository.GetBasketItemsCount(basketId);

    public async Task<BasketItem> PutInBasket(string basketId, BasketItem basketItem) {
        //Product? found = await repository.GetProduct(basketId, product.Id);
        //if (found is null) {
        //    found = await repository.AddProduct(basketId, product);
        //} else { 
        //    found = await repository.UpdateProduct(basketId, product);
        //}
        //return found;
        return await repository.AddBasketItem(basketId, basketItem);
    }

    public Task UpdateQuantity(string basketId, int basketItemId, int quantity) => repository.UpdateQuantity(basketId, basketItemId, quantity);
}
