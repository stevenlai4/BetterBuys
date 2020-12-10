using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Pages.Cart
{

    public class IndexModel : PageModel
    {
        private readonly StoreDbContext _db;

        public IndexModel(StoreDbContext db)
        {
            _db = db;
        }
        public List<Category> Categories { get; set; } = new List<Category>();
        public void OnGet()
        {
            Categories = _db.Categories.Select(cat => new Category(cat.Name)).ToList();
        }
    }
}
