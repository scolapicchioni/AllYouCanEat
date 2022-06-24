namespace Order.Core.Entities.Basket;
public class BasketItemAdditionalChoice {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> SelectedChoices { get; set; }
    //public List<AdditionalChoice>? AdditionalChoices { get; set; }

    public static BasketItemAdditionalChoice FromPossibleChoice(AdditionalChoice additionalChoice) {
        return new BasketItemAdditionalChoice() {
            Id = additionalChoice.Id,
            Name = additionalChoice.Name,
            SelectedChoices = additionalChoice.SelectedChoices.ToList()
        };
    }
}
