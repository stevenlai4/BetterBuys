using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class ShoppingCart : BaseEntity
    {
        public DateTime CreatedOn { get; private set; }
        public int Status { get; private set; }
        public string BuyerId { get; private set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual CheckoutInfo CheckoutInfo { get; set; }

        public ShoppingCart(string buyerId)
        {
            CreatedOn = DateTime.Now;
            BuyerId = buyerId;
        }

        public void setBuyer(string buyerId)
        {
            BuyerId = buyerId;
        }

        public void setStatus(int status)
        {
            Status = status;
        }
    }
}

