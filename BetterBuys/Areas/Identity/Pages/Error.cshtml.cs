using System.Diagnostics;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Areas.Identity.Pages
{
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {

        private readonly IProductVMService _productVMService;
        public ErrorModel(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }
        public string RequestId { get; set; }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ProductIndex = _productVMService.GetProductsVM(HttpContext, null);
        }
    }
}
