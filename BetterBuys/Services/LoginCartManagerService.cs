using BetterBuys.Data;
using BetterBuys.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BetterBuys.Services
{
    public class LoginCartManagerService
    {
        private readonly StoreDbContext _db;
        Claim user;

        public LoginCartManagerService(StoreDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        }

        public void ManageCart(HttpContext context)
        {
            int? cartId = context.Session.GetInt32("cartId");

            if (user != null)
            {
                string userId = user.Value;
                ShoppingCart? userCart = (from c in _db.Carts where c.BuyerId == userId && c.Status == 0 orderby c.CreatedOn ascending select c).FirstOrDefault();
                if (user != null)
                {

                }
            }
        }
    }
}
