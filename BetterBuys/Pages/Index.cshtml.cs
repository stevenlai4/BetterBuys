using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BetterBuys.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductVMService _productVMService;
        private readonly ILoginCartManagerService _loginCartManagerService;
        Claim user;

        public IndexModel(
            IProductVMService productVMService,
            ILoginCartManagerService loginCartManagerService,
            IHttpContextAccessor httpContextAccessor)
        {
            _productVMService = productVMService;
            _loginCartManagerService = loginCartManagerService;
            user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public Boolean IsFiltering = false;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Sort { get; set; }
        public int? CategoryID { get; set; }
        public async Task OnGetAsync(int? categoryId)
        {
            CategoryID = categoryId;
            IsFiltering = categoryId != null ? true : false;

            int? cartId = HttpContext.Session.GetInt32("cartId");

            //If logged in and without a cart session, check if there is a recent unclosed cart session
            if (user != null && cartId == null)
            {
                await _loginCartManagerService.ManageCart(HttpContext, user.Value);
            }

            ProductIndex = _productVMService.GetProductsVMFilteredSorted(HttpContext, CategoryID, SearchString, Sort);
            if (!String.IsNullOrEmpty(SearchString) || !String.IsNullOrEmpty(Sort))
            {
                IsFiltering = true;
            }
        }
    }
}
