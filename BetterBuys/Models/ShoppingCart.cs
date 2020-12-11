using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class ShoppingCart : BaseEntity
    {
        public string ShippingAddress { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public int Status { get; private set; }
        [Phone]
        public string Phone { get; set; }
        [StringLength(12)]
        [Required]
        public string CardNumber { get; set; }
        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string CardHolderName { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string ExpirationDate { get; set; }

        [StringLength(3)]
        [Required]
        public string CVW { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public ShoppingCart(string shippingAddress, DateTime createdOn, int status, string phone, string cardNumber, string cardHolderName,
                            string expirationDate, string cvw)
        {
            ShippingAddress = shippingAddress;
            CreatedOn = createdOn;
            Status = status;
            Phone = phone;
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationDate = expirationDate;
            CVW = cvw;
        }
    }
}

