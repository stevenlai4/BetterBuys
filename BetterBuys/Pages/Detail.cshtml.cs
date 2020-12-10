using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IProductVMService _productVMService;
        public DetailModel(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }
        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public List<Category> Categories { get; set; }
        public void OnGet(ProductIndexVM productIndex)
        {
            ProductIndex = _productVMService.GetProductsVM(productIndex.TypesFilterApplied);
            Categories = _productVMService.GetCategories();
        }
    }
}
