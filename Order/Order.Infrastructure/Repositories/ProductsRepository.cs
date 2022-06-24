using Order.Core.Entities;
using Order.Core.Interfaces;

namespace Order.Infrastructure.Repositories;
public class ProductsRepository : IProductsRepository {
    private List<Product> products  = new() {
        new Product() {
            Id = 1, Category = "Snacks", Name = "Vlees Kroket", GlutenFree = true, Vegetarian=false,
            AdditionalChoices = new List<AdditionalChoice>(){
                new AdditionalChoice(){
                    Id = 1,Name="Glutenvrij", MinimumSelectableChoices = 0, MaximumSelectableChoices = 1,
                    PossibleChoices = new List<string>() { "Glutenvrij" },
                    SelectedChoices = new List<string>()
                }
            }
        },
        new Product() {
            Id = 2, Category = "Snacks", Name = "Bami Schijf", GlutenFree = false, Vegetarian = true
        },
        new Product() {
            Id = 3, Category = "Snacks", Name = "Kaassouffle", GlutenFree = true, Vegetarian = true,
            AdditionalChoices = new List<AdditionalChoice>(){
                new AdditionalChoice(){
                    Id = 1,Name="Glutenvrij", MinimumSelectableChoices = 0, MaximumSelectableChoices = 1,
                    PossibleChoices = new List<string>() { "Glutenvrij" },
                    SelectedChoices = new List<string>()
                }
            }
        },
        new Product() {
            Id = 4, Category = "Dranken", Name = "Melk", GlutenFree = false, Vegetarian = true
        },
        new Product() {
            Id = 5, Category = "Dranken", Name = "Karnemelk", GlutenFree = false, Vegetarian = true
        },
        new Product() {
            Id = 6, Category = "Toetjes", Name = "Yogurtje rode vruchten", GlutenFree = false, Vegetarian = true
        },
        new Product() {
            Id = 7, Category = "Toetjes", Name = "Yogurtje tropische vruchten", GlutenFree = false, Vegetarian = true
        },
        new Product() {
            Id = 8, Category = "Broodjes", Name = "Jonge Kaas", GlutenFree = false, Vegetarian = true,
            AdditionalChoices = new List<AdditionalChoice>(){
                new AdditionalChoice(){
                    Id = 1,Name="Soort Brood", MinimumSelectableChoices = 1, MaximumSelectableChoices = 1,
                    PossibleChoices = new List<string>() { "Witte Bol", "Tarwe Bol", "Pistolet Wit", "Pistolet Bruin", "Waldkoorn" },
                    SelectedChoices = new List<string>() { "Witte Bol" }
                },
                new AdditionalChoice(){
                    Id = 2,Name="Ingredienten", MinimumSelectableChoices = 0, MaximumSelectableChoices = 2,
                    PossibleChoices = new List<string>() { "Boter", "Garnering" },
                    SelectedChoices = new List<string>() { "Boter", "Garnering" }
                }
            }
        },
        new Product() {
            Id = 9, Category = "Broodjes", Name = "Ham Kaas", GlutenFree = false, Vegetarian = false,
            AdditionalChoices = new List<AdditionalChoice>(){
                new AdditionalChoice(){
                    Id = 1,Name="Soort Brood", MinimumSelectableChoices = 1, MaximumSelectableChoices = 1,
                    PossibleChoices = new List<string>() { "Witte Bol", "Tarwe Bol", "Pistolet Wit", "Pistolet Bruin", "Waldkoorn" },
                    SelectedChoices = new List<string>() { "Witte Bol" }
                },
                new AdditionalChoice(){
                    Id = 2,Name="Ingredienten", MinimumSelectableChoices = 0, MaximumSelectableChoices = 2,
                    PossibleChoices = new List<string>() { "Boter", "Garnering" },
                    SelectedChoices = new List<string>() { "Boter", "Garnering" }
                }
            }
        },
        new Product() {
            Id = 10, Category = "Broodjes", Name = "Filet American Speciaal", GlutenFree = false, Vegetarian = false,
            AdditionalChoices = new List<AdditionalChoice>(){
                new AdditionalChoice(){
                    Id = 1,Name="Soort Brood", MinimumSelectableChoices = 1, MaximumSelectableChoices = 1,
                    PossibleChoices = new List<string>() { "Witte Bol", "Tarwe Bol", "Pistolet Wit", "Pistolet Bruin", "Waldkoorn" },
                    SelectedChoices = new List<string>() { "Witte Bol" }
                },
                new AdditionalChoice(){
                    Id = 2,Name="Ingredienten", MinimumSelectableChoices = 0, MaximumSelectableChoices = 2,
                    PossibleChoices = new List<string>() { "Boter", "Garnering" },
                    SelectedChoices = new List<string>() { "Boter", "Garnering" }
                }
            }
        }
    };
    public Task<Dictionary<string, List<Product>>> GetAvailableProductsAsync() {
        Dictionary<string, List<Product>> productsGroupedByCategory = products.GroupBy(p=>p.Category).ToDictionary(group=>group.Key, group => group.ToList());
        return Task.FromResult(productsGroupedByCategory);
    }

    public Task<Product?> GetProductById(int productId) {
        return Task.FromResult(products.FirstOrDefault(p => p.Id == productId));
    }
}
