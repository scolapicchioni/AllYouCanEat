using Blazored.LocalStorage;
using Moq;
using Order.Core.Entities.Basket;
using Order.Infrastructure.Repositories;

namespace Order.Infrastructure.UnitTests.Repositories; 
public class BasketRepositoryTests {
    Mock<ILocalStorageService> localStorageServiceMock;
    BasketRepository sut;
    string basketId;
    public BasketRepositoryTests() {
        localStorageServiceMock = new();
        basketId = "123456";

        sut = new BasketRepository(localStorageServiceMock.Object);
    }
    [Fact]
    public async Task GetBasket_ShouldReturnEmptyBasket_WhenBasketDoesNotExist() {        
        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(default(HashSet<BasketItem>));

        HashSet<BasketItem>? actual = await sut.GetBasket(basketId);
        Assert.NotNull(actual);
        Assert.Empty(actual);
    }

    [Fact]
    public async Task GetBasket_ShouldReturnExistingBasket_WhenBasketExists() {
        HashSet<BasketItem>? expected = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            new () {Id = 2, Name = "Product2", ProductId = 2, Quantity = 2}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(expected);

        HashSet<BasketItem>? actual = await sut.GetBasket(basketId);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UpsertBasketItem_ShouldSetBasketItemIdWithMaxId_WhenBasketExists() {
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            new () {Id = 2, Name = "Product2", ProductId = 2, Quantity = 2}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem itemToAdd = new BasketItem() { Name = "ProductToAdd", ProductId = 1, Quantity = 1 };

        BasketItem actual = await sut.UpsertBasketItem(basketId, itemToAdd);

        Assert.Equal(3, actual.Id);
    }

    [Fact]
    public async Task UpsertBasketItem_ShouldSetBasketItemIdWith1_WhenBasketDoesntExist() {
        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(default(HashSet<BasketItem>));

        BasketItem itemToAdd = new BasketItem() { Name = "ProductToAdd", ProductId = 1, Quantity = 1 };

        BasketItem actual = await sut.UpsertBasketItem(basketId, itemToAdd);

        Assert.Equal(1, actual.Id);
    }

    [Fact]
    public async Task UpsertBasketItem_ShouldAddItemToBasket_WhenItemIsNotPresent() {
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            new () {Id = 2, Name = "Product2", ProductId = 2, Quantity = 2}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem itemToAdd = new BasketItem() { Name = "ProductToAdd", ProductId = 1, Quantity = 1};

        BasketItem actual = await sut.UpsertBasketItem(basketId, itemToAdd);

        Assert.Contains(itemToAdd, basket);
        Assert.Equal(3,basket.Count);
    }

    [Fact]
    public async Task UpsertBasketItem_ShouldReplaceItemIfAlreadyPresent() {
        BasketItem itemToReplace = new() { Id = 1, Name = "Product1", ProductId = 1, Quantity = 1 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){ itemToReplace });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem itemToAdd = new BasketItem() { Name = "ProductToAdd", ProductId = 1, Quantity = 1, Id = 1 };

        BasketItem actual = await sut.UpsertBasketItem(basketId, itemToAdd);

        Assert.Contains<BasketItem>(itemToAdd, basket);
        Assert.DoesNotContain<BasketItem>(itemToReplace, basket);
    }

    [Fact]
    public async Task UpsertBasketItem_ShouldSaveBasketInLocalStorage() {
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            new () {Id = 2, Name = "Product2", ProductId = 2, Quantity = 2}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem itemToAdd = new BasketItem() { Name = "ProductToAdd", ProductId = 1, Quantity = 1 };

        BasketItem actual = await sut.UpsertBasketItem(basketId, itemToAdd);

        localStorageServiceMock.Verify(ls => ls.SetItemAsync(basketId, basket, default));
    }

    [Fact]
    public async Task DeleteBasketItem_ShouldRemoveItemFromBasket_WhenFound() {
        BasketItem itemToRemove = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            itemToRemove,
            new () {Id = 3, Name = "Product3", ProductId = 3, Quantity = 3}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem? actual = await sut.DeleteBasketItem(basketId, itemToRemove.Id);

        Assert.DoesNotContain(itemToRemove, basket);
        
    }

    [Fact]
    public async Task DeleteBasketItem_ShouldReturnDeletedItem_WhenFound() {
        BasketItem itemToRemove = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            itemToRemove,
            new () {Id = 3, Name = "Product3", ProductId = 3, Quantity = 3}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem? actual = await sut.DeleteBasketItem(basketId, itemToRemove.Id);

        Assert.NotNull(actual);
        Assert.Equal(itemToRemove, actual);
    }

    [Fact]
    public async Task DeleteBasketItem_ShouldSaveBasketInLocalStorage_WhenFound() {
        BasketItem itemToRemove = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            itemToRemove,
            new () {Id = 3, Name = "Product3", ProductId = 3, Quantity = 3}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem? actual = await sut.DeleteBasketItem(basketId, itemToRemove.Id);

        localStorageServiceMock.Verify(ls => ls.SetItemAsync(basketId, basket, default));
    }

    [Fact]
    public async Task DeleteBasketItem_ShouldReturnNull_WhenNotFound() {
        BasketItem itemToRemove = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            new () {Id = 3, Name = "Product3", ProductId = 3, Quantity = 3}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem? actual = await sut.DeleteBasketItem(basketId, itemToRemove.Id);

        Assert.Null(actual);

    }


    [Fact]
    public async Task GetBasketItem_ShouldReturnItem_WhenItemExists() {
        BasketItem expected = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            expected,
            new () {Id = 3, Name = "Product3", ProductId = 3, Quantity = 3}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem? actual = await sut.GetBasketItem(basketId, expected.Id);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetBasketItem_ShouldReturnNull_WhenItemDoesNotExist() {
        
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            new () {Id = 1, Name = "Product1", ProductId = 1, Quantity = 1},
            new () {Id = 3, Name = "Product3", ProductId = 3, Quantity = 3}
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        BasketItem? actual = await sut.GetBasketItem(basketId, 2);

        Assert.Null(actual);
    }

    [Fact]
    public async Task GetBasketItems_ShouldReturnListOfItems_WhenBasketExists() {
        BasketItem item1 = new() { Id = 1, Name = "Product1", ProductId = 1, Quantity = 1 };
        BasketItem item2 = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        BasketItem item3 = new() { Id = 3, Name = "Product3", ProductId = 3, Quantity = 3 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            item1, item2, item3
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        IEnumerable<BasketItem> actual = await sut.GetBasketItems(basketId);

        List<BasketItem> list = Assert.IsAssignableFrom<List<BasketItem>>(actual);
        Assert.Equal(3, list.Count);
        Assert.Contains(item1, list);
        Assert.Contains(item2, list);
        Assert.Contains(item3, list);
    }

    [Fact]
    public async Task GetBasketItems_ShouldReturnEmptyListOfItems_WhenBasketDoesNotExist() {
        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(new HashSet<BasketItem>());

        IEnumerable<BasketItem> actual = await sut.GetBasketItems(basketId);

        List<BasketItem> list = Assert.IsAssignableFrom<List<BasketItem>>(actual);
        Assert.NotNull(list);
        Assert.Empty(list);
    }

    [Fact]
    public async Task GetBasketItemsCount_ShouldReturnCountOfExistingItems_WhenBasketExists() {
        BasketItem item1 = new() { Id = 1, Name = "Product1", ProductId = 1, Quantity = 1 };
        BasketItem item2 = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        BasketItem item3 = new() { Id = 3, Name = "Product3", ProductId = 3, Quantity = 3 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            item1, item2, item3
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        int expected = 3;
        int actual = await sut.GetBasketItemsCount(basketId);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetBasketItems_ShouldReturnZero_WhenBasketDoesNotExist() {
        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(new HashSet<BasketItem>());
        
        int expected = 0;
        int actual = await sut.GetBasketItemsCount(basketId);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UpdateQuantity_ShouldUpdateItemQuantity_WhenBasketItemExists() {
        BasketItem item1 = new() { Id = 1, Name = "Product1", ProductId = 1, Quantity = 1 };
        BasketItem item2 = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        BasketItem item3 = new() { Id = 3, Name = "Product3", ProductId = 3, Quantity = 3 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            item1, item2, item3
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        int expected = 3;
        await sut.UpdateQuantity(basketId,item2.Id,expected);

        Assert.Equal(expected, item2.Quantity);
    }

    [Fact]
    public async Task UpdateQuantity_ShouldRemoveItem_WhenBasketItemExistsAndQuantityIsZero() {
        BasketItem item1 = new() { Id = 1, Name = "Product1", ProductId = 1, Quantity = 1 };
        BasketItem item2 = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        BasketItem item3 = new() { Id = 3, Name = "Product3", ProductId = 3, Quantity = 3 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            item1, item2, item3
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        int newQuantity = 0;
        await sut.UpdateQuantity(basketId, item2.Id, newQuantity);

        Assert.DoesNotContain(item2, basket);
    }
    [Fact]
    public async Task UpdateQuantity_ShouldSaveBasketToLocalStorage() {
        BasketItem item1 = new() { Id = 1, Name = "Product1", ProductId = 1, Quantity = 1 };
        BasketItem item2 = new() { Id = 2, Name = "Product2", ProductId = 2, Quantity = 2 };
        BasketItem item3 = new() { Id = 3, Name = "Product3", ProductId = 3, Quantity = 3 };
        HashSet<BasketItem>? basket = new HashSet<BasketItem>(new List<BasketItem>(){
            item1, item2, item3
        });

        localStorageServiceMock.Setup(ls => ls.GetItemAsync<HashSet<BasketItem>>(basketId, default)).ReturnsAsync(basket);

        int newQuantity = 3;
        await sut.UpdateQuantity(basketId, item2.Id, newQuantity);

        localStorageServiceMock.Verify(ls => ls.SetItemAsync(basketId, basket, default));
    }

}
