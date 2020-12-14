using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Areas.Identity.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {
        private readonly IProductVMService _productVMService;

        public AccessDeniedModel(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();

        public void OnGet(int? categoryId)
        {
            ProductIndex = _productVMService.GetProductsVM(HttpContext, categoryId);
        }
    }
}

