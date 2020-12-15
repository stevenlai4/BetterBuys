using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IProductVMService _productVMService;
        private readonly StoreDbContext _db;
        public string warningMsg = "";
        Claim user;
        public DetailModel(IProductVMService productVMService, StoreDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _productVMService = productVMService;
            _db = db;
            user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public ProductVM ProductDetail { get; private set; }

        public void OnGet(int productId)
        {
            ProductDetail = _productVMService.GetProduct(productId);
            ProductIndex = _productVMService.GetProductsVM(HttpContext, null);
        }

        public ShoppingCart Cart { get; set; }

        // Add a product to the cart
        public IActionResult OnPost(int productId, ProductVM product)
        {
            ProductDetail = _productVMService.GetProduct(productId);

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
                if ((cp.Quantity + product.Quantity) <= 50) // Add quantity if won't exceed 50
                {
                    cp.AddQuantity(product.Quantity);
                }
                else if(cp.Quantity == 50) // Display alert for exactly 50
                {
                    warningMsg = product.Name + " already reaches highest quantity of 50!";
                }
                else // Display alert if the added quantity will exceed 50
                {
                    warningMsg = "Exceeding quantity limit of 50! You can only add " + (50 - cp.Quantity) + " more of " + product.Name + "!";
                }
            }

            _db.SaveChanges();

            HttpContext.Session.SetInt32("cartId", (int)cartId);

            ProductIndex = _productVMService.GetProductsVM(HttpContext, null);

            return Page();
        }
    }
}
