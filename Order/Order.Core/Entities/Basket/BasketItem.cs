namespace Order.Core.Entities.Basket; 
public class BasketItem {
    public static BasketItem FromProduct(Product origin) { 
        BasketItem basketItem = new BasketItem();
        basketItem.ProductId = origin.Id;
        basketItem.Name = origin.Name;
        basketItem.Quantity = 1;

        basketItem.AdditionalChoices = new List<BasketItemAdditionalChoice>();
        if (origin.AdditionalChoices is not null) {
            foreach (var originChoice in origin.AdditionalChoices) {
                BasketItemAdditionalChoice additionalChoice = new BasketItemAdditionalChoice();
                additionalChoice.Id = originChoice.Id;
                additionalChoice.Name = originChoice.Name;
                if (originChoice.SelectedChoices is not null) {
                    additionalChoice.SelectedChoices = originChoice.SelectedChoices.ToList();
                }
                basketItem.AdditionalChoices.Add(additionalChoice);
            }
        }
        return basketItem;
    }
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public List<BasketItemAdditionalChoice>? AdditionalChoices { get; set; }
}
