using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            ProductIndex = _productVMService.GetProductsVM(productIndex.TypesFilterApplied);
            Categories = new List<Category>
            {
                new Category("Clothes"),
                new Category("Books"),
                new Category("Electronics"),
                new Category("Jewellery"),
                new Category("Sport")

            };
        }
    }
}
