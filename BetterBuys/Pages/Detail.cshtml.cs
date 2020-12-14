using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;
using BetterBuys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

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
        public ProductVM ProductDetail { get; private set; }

        public void OnGet(int productId, int? categoryId)
        {
            ProductDetail = _productVMService.GetProduct(productId);
            ProductIndex = _productVMService.GetProductsVM(HttpContext, categoryId);
            ViewData["returnUrl"] = HttpContext.Request.Host.Value;
        }
    }
}
