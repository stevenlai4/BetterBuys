using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        private readonly IProductVMService _productVMService;

        public ForgotPasswordConfirmation(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();

        public void OnGet(int? categoryId)
        {
            ProductIndex = _productVMService.GetProductsVM(categoryId);
        }
    }
}
