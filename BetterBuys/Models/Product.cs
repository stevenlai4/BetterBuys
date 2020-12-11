using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        [Column(TypeName = "money")]
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string ImageUri { get; private set; }
     
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }

        public Product(string name, string description, decimal price, string imageUri)
        { 
            Name = name;
            Description = description;
            Price = price;
            ImageUri = imageUri;
        }

       
    }
}
