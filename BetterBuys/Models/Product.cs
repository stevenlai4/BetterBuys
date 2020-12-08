using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
