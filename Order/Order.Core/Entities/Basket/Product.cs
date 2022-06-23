using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Core.Entities.Basket {
    public class Product {
        public static Product FromFullProduct(Order.Core.Entities.Product origin) { 
            Product product = new Product();
            product.Id = origin.Id;
            product.Name = origin.Name;
            product.Quantity = 1;

            product.AdditionalChoices = new List<AdditionalChoice>();
            foreach (var originChoice in origin.AdditionalChoices) {
                AdditionalChoice additionalChoice = new AdditionalChoice();
                additionalChoice.Id = originChoice.Id;
                additionalChoice.Name = originChoice.Name;
                additionalChoice.SelectedChoices = originChoice.SelectedChoices.ToArray();
                product.AdditionalChoices.Add(additionalChoice);
            }
            return product;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<AdditionalChoice>? AdditionalChoices { get; set; }
    }
}
