using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
        public int Quantity { get; set; }
        public ProductVM()
        {
            Quantity = 1;
        }
    }
}
