using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BetterBuys.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StoreDbContext _db;

        public IndexModel(ILogger<IndexModel> logger, StoreDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = new List<Category>
            {
                new Category("Clothes"),
                new Category("Books"),
                new Category("Electronics"),
                new Category("Jewellery"),
                new Category("Sport")

            };
        }
    }
}
