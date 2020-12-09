using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}
