using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BetterBuys.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductVMService _productVMService;
        private readonly StoreDbContext _db;

        public IndexModel(IProductVMService productVMService, StoreDbContext db)
        {
            _productVMService = productVMService;
            _db = db;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public Boolean IsFiltering = false;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }   
        public void OnGet(int? categoryId)
        {
            IsFiltering = categoryId != null ? true : false;
            ProductIndex = _productVMService.GetProductsVM(categoryId);
            if (!string.IsNullOrEmpty(SearchString))
            {
                ProductIndex = new ProductIndexVM()
                {
                    Products = (from p in ProductIndex.Products
                                where p.Name.ToLower().Contains(SearchString.ToLower())
                                select p).ToList(),
                    Categories = ProductIndex.Categories
                };
            }

        }
    }
}
