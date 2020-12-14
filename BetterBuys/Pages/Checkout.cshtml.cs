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
        }

        CheckoutInfo checkoutInfo;
        public async Task<IActionResult> onPost()
        {

            if (!ModelState.IsValid)
            {
                //checkoutInfo = new CheckoutInfo(null);
                await _db.CheckoutInfos.AddAsync(checkoutInfo);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }
            HttpContext.Session.Remove("cartId");
            return RedirectToPage("~/Index");
        }
    }
}


