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
        private readonly StoreDbContext _db;
        public string warningMsg = "";
        Claim user;

        public IndexModel(IProductVMService productVMService, ILoginCartManagerService loginCartManagerService, StoreDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _productVMService = productVMService;
            _loginCartManagerService = loginCartManagerService;
            _db = db;
            user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public Boolean IsFiltering = false;
        public ShoppingCart Cart { get; set; }
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

        // Add a product to the cart
        public IActionResult OnPost(int? categoryId, ProductVM product)
        {
            IsFiltering = categoryId != null ? true : false;

            if (product?.Id == null)
            {
                return RedirectToPage("/Index");
            }
            //need to validate against user or session
            int? cartId = HttpContext.Session.GetInt32("cartId");

            if (cartId == null) //new cart
            {
                Cart = new ShoppingCart(user == null ? null : user.Value);
                _db.Carts.Add(Cart);
                _db.SaveChanges();
                cartId = Cart.Id;
            }

            //update existing prod in existing cart
            CartProduct cp;
            //add new prod to existing cart 

            cp = _db.CartProducts.Where(cp => cp.CartId == cartId && cp.ProductId == product.Id)
                .FirstOrDefault();

            if (cp == null) //product not in this cart yet
            {
                cp = new CartProduct((int)cartId, product.Id, product.Price, product.Quantity);
                _db.CartProducts.Add(cp);

            }
            else //product is already in cart
            {
                //might want to validate for price change in the future;
                if ((cp.Quantity + product.Quantity) <= 50)  // Add quantity if won't exceed 50
                {
                    cp.AddQuantity(product.Quantity);
                }
                else // Display alert for exactly 50
                {
                    warningMsg = product.Name + " already reaches highest quantity of 50!";
                }
            }

            _db.SaveChanges();

            HttpContext.Session.SetInt32("cartId", (int)cartId);

            ProductIndex = _productVMService.GetProductsVM(HttpContext, categoryId);

            return Page();
        }
    }
}
