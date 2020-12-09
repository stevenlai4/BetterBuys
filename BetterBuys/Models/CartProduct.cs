using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class CartProduct
    {
        [Key, Column(Order = 0)]
        public int CartId { get; private set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; private set; }
        [Column(TypeName = "money")]
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
