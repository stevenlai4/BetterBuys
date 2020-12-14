using System;
using System.Collections.Generic;
using System.Linq;
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
        public DetailModel(IProductVMService productVMService, StoreDbContext db)
        {
            _productVMService = productVMService;
            _db = db;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public ProductVM ProductDetail { get; private set; }

        public void OnGet(int productId, int? categoryId)
        {
            ProductDetail = _productVMService.GetProduct(productId);
            ProductIndex = _productVMService.GetProductsVM(categoryId);
        }

        public ShoppingCart Cart { get; set; }

        // Add a product to the cart
        public IActionResult OnPost(int? categoryId, int productId, ProductVM testProduct)
        {
            ProductDetail = _productVMService.GetProduct(productId);
            ProductIndex = _productVMService.GetProductsVM(categoryId);

            if (testProduct?.Id == null)
            {
                return RedirectToPage("/Index");
            }

            //need to validate against user or session
            int? cartId = HttpContext.Session.GetInt32("cartId");

            if (cartId == null) //new cart
            {
                Cart = new ShoppingCart();
                _db.Carts.Add(Cart);
                _db.SaveChanges();
                cartId = Cart.Id;
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

            return Page();
        }
    }
}
