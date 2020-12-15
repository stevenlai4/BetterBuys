using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BetterBuys.Services
{
    public class LoginCartManagerService : ILoginCartManagerService
    {
        private readonly StoreDbContext _db;

        public LoginCartManagerService(StoreDbContext db)
        {
            _db = db;
        }

        public async Task ManageCart(HttpContext context, string userId)
        {
            int? cartId = context.Session.GetInt32("cartId");
            ShoppingCart Cart;

            int? userCartId = (from c in _db.Carts where c.BuyerId == userId && c.Status == 0 orderby c.CreatedOn descending select c.Id).FirstOrDefault();
                
            //If there is a unclosed cart assoicated with the user
            if (userCartId != 0)
            {
                //If there is no cart in session, set the most recent unclosed cart as the session
                if (cartId == null)
                {
                    context.Session.SetInt32("cartId", (int)userCartId);
                }
                //If there is a cart in session, merge most recent unclosed cart with the current session
                else
                {
                    IQueryable<CartProduct> oldCart;
                    oldCart = _db.CartProducts.Where(cp => cp.CartId == userCartId);

                    //Merge each item of the old cart to the cart in session
                    foreach (var cartItem in oldCart)
                    {
                        var productId = cartItem.ProductId;
                        CartProduct newCart = _db.CartProducts.Where(cp => cp.CartId == cartId && cp.ProductId == productId).FirstOrDefault();

                        if (newCart == null) //product not in this cart yet
                        {
                            newCart = new CartProduct((int)cartId, productId, cartItem.Price, cartItem.Quantity);
                            _db.CartProducts.Add(newCart);

                        }
                        else //product is already in cart
                        {
                            if ((newCart.Quantity + cartItem.Quantity) <= 50) // Add quantity if won't exceed 50
                            {
                                newCart.AddQuantity(cartItem.Quantity);
                            }
                            else //Cap quantity at 50 in this merge
                            {
                                newCart.updateQuantity(50);
                            }
                        }
                    }

                    //Set the current cart session with the userId
                    Cart = _db.Carts.Where(c => c.Id == cartId).FirstOrDefault();
                    Cart.setBuyer(userId);
                    //Delete old cart
                    Cart = _db.Carts.Where(c => c.Id == userCartId).FirstOrDefault();
                    _db.Carts.Remove(Cart);

                    await _db.SaveChangesAsync();
                }
            }
            //No unclosed session
            else
            {
                if (cartId != null)
                {
                    Cart = _db.Carts.Where(c => c.Id == cartId).FirstOrDefault();
                    Cart.setBuyer(userId);
                    await _db.SaveChangesAsync();
                }
            }
        }
    }
}
