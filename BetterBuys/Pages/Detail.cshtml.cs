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
        protected readonly StoreDbContext _db; 
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public Product Product { get; set; }
       
        public Product OnGet(int id)
        {
          Product product = new Product();
          product = (Product)_db.Products.Where(p=>p.Id==id);
            return product;
          
        }
    }
}
