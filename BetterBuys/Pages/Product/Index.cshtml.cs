using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductVM> Products { get; set; } = new List<ProductVM>();
        public void OnGet()
        {
            Products.Add(new ProductVM
            {
                Id = 1,
                Name = "Placeholder",
                Price = 999,
                ImageUri = ""
            });
            Products.Add(new ProductVM
            {
                Id = 2,
                Name = "Placeholder2",
                Price = 444,
                ImageUri = ""
            });
            Products.Add(new ProductVM
            {
                Id = 3,
                Name = "Placeholder3",
                Price = 111,
                ImageUri = ""
            });
            Products.Add(new ProductVM
            {
                Id = 4,
                Name = "Placeholder4",
                Price = 777,
                ImageUri = ""
            });
        }
    }
}
