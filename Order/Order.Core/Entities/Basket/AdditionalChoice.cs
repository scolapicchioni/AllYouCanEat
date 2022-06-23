namespace Order.Core.Entities.Basket;
public class AdditionalChoice {
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] SelectedChoices { get; set; }
    public List<AdditionalChoice>? AdditionalChoices { get; set; }
}
