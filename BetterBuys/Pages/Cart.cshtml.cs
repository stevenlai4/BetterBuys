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

        public CartModel(IProductVMService productVMService, StoreDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _productVMService = productVMService;
            _db = db;
            
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public List<ProductVM> productsInCart { get; set; } = new List<ProductVM>();
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
