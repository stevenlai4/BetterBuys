using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class Cart : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Status { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
