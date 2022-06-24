namespace Order.Core.Entities;
public class AdditionalChoice  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string>  PossibleChoices { get; set; }
    public int MinimumSelectableChoices { get; set; }
    public int MaximumSelectableChoices { get; set; }
    public List<string> SelectedChoices { get; set; }
}
