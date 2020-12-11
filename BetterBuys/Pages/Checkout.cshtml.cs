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
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly IProductVMService _productVMService;

        public CheckoutModel(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }
        private readonly StoreDbContext _db;
        public CheckoutModel(StoreDbContext db)
        {
            _db = db;
        }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();
        public void OnGet(int? categoryId)
        {
            ProductIndex = _productVMService.GetProductsVM(categoryId);
        }
        public ShoppingCart ShoppingCart { get; set; }
        public void OnGet()  
        {
            int? cartId = HttpContext.Session.GetInt32("cartId");
            if (cartId != null)
                ShoppingCart = _db.Carts
                    .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                    .Where(c => c.Id == (int)HttpContext.Session.GetInt32("cartId"))
                    .FirstOrDefault();

            //HttpContext.Session.Remove("cartId");
        }
    }
}
