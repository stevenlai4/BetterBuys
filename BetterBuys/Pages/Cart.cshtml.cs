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

        public ShoppingCart Cart { get; set; }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public void OnGet(int? categoryId)
        {
            ProductIndex = _productVMService.GetProductsVM(categoryId);

            Cart = _db.Carts
               .Include(c => c.CartProducts)
               .ThenInclude(cp => cp.Product)
               .Where(c => c.Id == (int)HttpContext.Session.GetInt32("cartId"))
               .FirstOrDefault();
        }
        public IActionResult OnPost(ProductVM testProduct)
        {
            if (testProduct?.Id == null)
            {
                return RedirectToPage("/Index");
            }
            //need to validate against user or session
            int? cartId = HttpContext.Session.GetInt32("cartId");
            ////add new prod to new cart
            if (cartId == null) //new cart
            {
                Cart = new ShoppingCart(user == null ? null : user.Value);
                _db.Carts.Add(Cart);
                _db.SaveChanges();
                cartId = Cart.Id;
            }
            else
            {
                Cart = _db.Carts.Where(c => c.Id == cartId).FirstOrDefault();
                Cart.setBuyer(user == null ? null : user.Value);
            }

            //update existing prod in existing cart
            CartProduct cp;
            //add new prod to existing cart 

            cp = _db.CartProducts.Where(cp => cp.CartId == cartId && cp.ProductId == testProduct.Id)
                .FirstOrDefault();


            if (cp == null) //product not in this cart yet
            {
                cp = new CartProduct((int)cartId, testProduct.Id, testProduct.Price, testProduct.Quantity);
                _db.CartProducts.Add(cp);

            }

            else //product is already in cart
            {
                //might want to validate for price change in the future;
                cp.AddQuantity(testProduct.Quantity);
            }

            _db.SaveChanges();

            HttpContext.Session.SetInt32("cartId", (int)cartId);

            return RedirectToPage();
        }
    }
}
