using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BetterBuys.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly StoreDbContext _db;
        public IndexModel(StoreDbContext db)
        {
            _db = db;
        }

        public List<ProductVM> Products { get; set; } = new List<ProductVM>();
        public async Task OnGet()
        {
            Products = await _db.Products.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUri = p.ImageUri
            }).ToListAsync();
        }
    }
}
