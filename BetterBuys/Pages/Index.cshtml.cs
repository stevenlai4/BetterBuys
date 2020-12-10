using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BetterBuys.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductVMService _productVMService;
        public IndexModel(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public void OnGet(ProductIndexVM productIndex)
        {
            ProductIndex = _productVMService.GetProductsVM(productIndex.TypesFilterApplied);
        }
    }
}
