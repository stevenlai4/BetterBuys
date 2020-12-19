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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BetterBuys.Pages.Cart
{

    public class CartModel : PageModel
    {

        private readonly IProductVMService _productVMService;
        private readonly StoreDbContext _db;
        Claim user;

        public CartModel(IProductVMService productVMService, StoreDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _productVMService = productVMService;
            _db = db;
            user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public List<ProductVM> productsInCart { get; set; } = new List<ProductVM>();
        public ShoppingCart Cart { get; set; }
        public void OnGet()
        {
            ProductIndex = _productVMService.GetProductsVM(HttpContext, null);

            if (HttpContext.Session.GetInt32("cartId") != null)
            {
                productsInCart = (from p in ProductIndex.Products
                                  join cp in _db.CartProducts on p.Id equals cp.ProductId
                                  where cp.CartId == (int)HttpContext.Session.GetInt32("cartId")
                                  select p).ToList();
            }
        }

        // Calculate total price without delivery fee
        public decimal CalTotal(List<ProductVM> productList)
        {
            decimal total = 0;
            foreach(var item in productList)
            {
                total += (item.Price * item.Quantity);
            }
            return total;
        }

        // Add a product to the cart
        public IActionResult OnPost(int? categoryId, ProductVM product)
        {
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
            }

            _db.SaveChanges();

            HttpContext.Session.SetInt32("cartId", (int)cartId);

            ProductIndex = _productVMService.GetProductsVM(HttpContext, categoryId);

            return RedirectToPage();
        }

        // method of the update
        public async Task<IActionResult> OnPostUpdate(int quantity, int? categoryId, int? productId)
        {
            ProductIndex = _productVMService.GetProductsVM(HttpContext, categoryId);

            int? cartId = HttpContext.Session.GetInt32("cartId");

            var cartProduct = await _db.CartProducts.Where(cp => cp.CartId == cartId && cp.ProductId == productId).FirstOrDefaultAsync();

            if(cartProduct != null)
            {
                cartProduct.updateQuantity(quantity);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("Cart");
        }

        //method for the delete
        public async Task<IActionResult> OnPostDelete(int? productId)
        {
            int? cartId = HttpContext.Session.GetInt32("cartId");
            var cartproducts = await _db.CartProducts.Where(cp => cp.CartId == cartId && cp.ProductId == productId).FirstOrDefaultAsync();

            if (cartproducts == null)
            {
                return NotFound();
            }
            _db.CartProducts.Remove(cartproducts);
            await _db.SaveChangesAsync();

            return RedirectToPage("Cart");
        }
    }
}
