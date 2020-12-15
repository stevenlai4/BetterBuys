using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BetterBuys.Pages.Checkout
{
    //[Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly IProductVMService _productVMService;
        private readonly StoreDbContext _db;
        public CheckoutModel(IProductVMService productVMService, StoreDbContext db)
        {
            _productVMService = productVMService;
            _db = db;
        }
        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public ShoppingCart ShoppingCart { get; set; } 
        public void OnGet(int? categoryId)  
        {
            ProductIndex = _productVMService.GetProductsVM(categoryId);
            int? cartId = HttpContext.Session.GetInt32("cartId");
            if (cartId != null)
                ShoppingCart = _db.Carts
                    .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                    .Where(c => c.Id == (int)HttpContext.Session.GetInt32("cartId"))
                    .FirstOrDefault();

            if (HttpContext.Session.GetInt32("cartId") != null)
            {
                productsInCart = (from p in ProductIndex.Products
                                  join cp in _db.CartProducts on p.Id equals cp.ProductId
                                  where cp.CartId == (int)HttpContext.Session.GetInt32("cartId")
                                  select p).ToList();
            }
        }

        public CheckoutInfo checkoutInfo;
        public async Task<IActionResult> OnPost(string firstName, string lastName, string address, string apartment, string city,
                                                string country, string province, string postalCode, string phone,
                                                string cardNumber, string cardHolderName, string expirationDate)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Checkout");
            }
            else
            {
                checkoutInfo = new CheckoutInfo(HttpContext.Session.GetInt32("cartId"), firstName, lastName, address, apartment, city,
                                             country, province, postalCode, phone, cardNumber, cardHolderName, expirationDate);
                await _db.CheckoutInfos.AddAsync(checkoutInfo);
                await _db.SaveChangesAsync();
                HttpContext.Session.Remove("cartId");
                return RedirectToPage("index");
            }
        }
        public List<ProductVM> productsInCart { get; set; } = new List<ProductVM>();
        public decimal CalTotal(List<ProductVM> productList)
        {
            decimal total = 0;
            foreach (var item in productList)
            {
                total += item.Price;
            }
            return total;
        }
        public decimal CalFinalTotal(List<ProductVM> productList)
        {
            decimal total = 0;
            foreach (var item in productList)
            {
                total += item.Price;
            }
            return total + 8;
        }
    }
}


