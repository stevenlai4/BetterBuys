using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class ProductCategory
    {
        [Key, Column(Order = 0)]
        public int CategoryId { get; private set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; private set; }
        
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }

        public ProductCategory(int categoryId, int productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }
    }
}
