using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;

namespace BetterBuys.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IProductVMService _productVMService;

        public PrivacyModel(ILogger<PrivacyModel> logger,
            IProductVMService productVMService)
        {
            _logger = logger;
            _productVMService = productVMService;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();

        public void OnGet(int? categoryId)
        {
            ProductIndex = _productVMService.GetProductsVM(categoryId);
        }
    }
}
