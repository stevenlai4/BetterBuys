using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Models
{
    public class CheckoutInfo : BaseEntity
    {
        public int CartId { get; private set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Apartment { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Phone]
        [Required]
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

        public virtual ShoppingCart Cart { get; set; }

        //public CheckoutInfo(int cartId, string shippingAddress, string phone, string cardNumber, string expirationDate, string cvw)
        //{
        //    CartId = cartId;
        //    ShippingAddress = shippingAddress;
        //    Phone = phone;
        //    CardNumber = cardNumber;
        //    ExpirationDate = expirationDate;
        //    CVW = cvw;
        //}
    }
}
