using Order.Core.Entities;
using Order.Core.Interfaces;

namespace Order.Infrastructure.Repositories;
public class ProductsRepository : IProductsRepository {
    public Task<Dictionary<string, List<Product>>> GetAvailableProductsAsync() {
        Dictionary<string, List<Product>> products = new() {
            { "Snacks", new List<Product>() {
                new Product() {
                    Id = 1, Category = "Snacks", Name = "Vlees Kroket", GlutenFree = true, Vegetarian=false, Quantity = 1,
                    AdditionalChoices = new List<AdditionalChoice>(){
                        new AdditionalChoice(){
                            Id = 1,Name="Glutenvrij", MinimumSelectableChoices = 0, MaximumSelectableChoices = 1,
                            PossibleChoices = new List<string>() { "Glutenvrij" },
                            SelectedChoices = new List<string>()
                        }
                    }
                },
                new Product() {
                    Id = 2, Category = "Snacks", Name = "Bami Schijf", GlutenFree = false, Vegetarian = true, Quantity = 1
                },
                new Product() {
                    Id = 3, Category = "Snacks", Name = "Kaassouffle", GlutenFree = true, Vegetarian = true, Quantity = 1,
                    AdditionalChoices = new List<AdditionalChoice>(){
                        new AdditionalChoice(){
                            Id = 1,Name="Glutenvrij", MinimumSelectableChoices = 0, MaximumSelectableChoices = 1,
                            PossibleChoices = new List<string>() { "Glutenvrij" },
                            SelectedChoices = new List<string>()
                        }
                    }
                }
            }},
            { "Dranken", new List<Product>(){
                new Product() {
                    Id = 4, Category = "Dranken", Name = "Melk", GlutenFree = false, Vegetarian = true, Quantity = 1
                },
                new Product() {
                    Id = 5, Category = "Dranken", Name = "Karnemelk", GlutenFree = false, Vegetarian = true, Quantity = 1
                }
            }},
            { "Toetjes", new List<Product>(){
                new Product() {
                    Id = 6, Category = "Toetjes", Name = "Yogurtje rode vruchten", GlutenFree = false, Vegetarian = true, Quantity = 1
                },
                new Product() {
                    Id = 7, Category = "Toetjes", Name = "Yogurtje tropische vruchten", GlutenFree = false, Vegetarian = true, Quantity = 1
                }
            }},
            { "Broodjes", new List<Product>(){
                new Product() {
                    Id = 8, Category = "Broodjes", Name = "Jonge Kaas", GlutenFree = false, Vegetarian = true, Quantity = 1,
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
                    Id = 9, Category = "Broodjes", Name = "Ham Kaas", GlutenFree = false, Vegetarian = false, Quantity = 1,
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
                    Id = 10, Category = "Broodjes", Name = "Filet American Speciaal", GlutenFree = false, Vegetarian = false, Quantity=1,
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
            }}
        };
        return Task.FromResult(products);
    }
}
