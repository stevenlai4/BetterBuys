using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;

namespace BetterBuys.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        private readonly IProductVMService _productVMService;
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger, IProductVMService productVMService)
        {
            _logger = logger;
            _productVMService = productVMService;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();

        public void OnGet()
        {
            ProductIndex = _productVMService.GetProductsVM(HttpContext, null);
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
