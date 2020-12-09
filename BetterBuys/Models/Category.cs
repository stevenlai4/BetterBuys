using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
