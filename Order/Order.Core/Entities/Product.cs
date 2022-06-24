namespace Order.Core.Entities; 
public class Product {
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool Vegetarian { get; set; }
    public bool GlutenFree { get; set; }
    public List<AdditionalChoice>? AdditionalChoices { get; set; }
}
