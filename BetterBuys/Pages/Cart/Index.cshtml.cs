using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Pages.Cart
{

    public class IndexModel : PageModel
    {
        private readonly IProductVMService _productVMService;

        public IndexModel(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }
        public List<Category> Categories { get; set; } = new List<Category>();
        public void OnGet()
        {
            Categories = _productVMService.GetCategories();
        }
    }
}
