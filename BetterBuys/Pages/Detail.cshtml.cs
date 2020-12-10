using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterBuys.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IBaseRepository<Product> _productRepo;
        public ProductVM Product = new ProductVM();

        public DetailModel(IBaseRepository<Product> productRepo)
        {
            _productRepo = productRepo;
            
        }
        public void OnGet(int id)
        {
            IQueryable<Product> products = _productRepo.GetAll();
            //Product = products.Where(p=>p.ProductId == id)
            Product = products.Where(p => p.Id == id);
        }
    }
}


public ProductVMService(IBaseRepository<Product> productRepo, IBaseRepository<Category> categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public ProductIndexVM GetProductsVM(int? categoryId)
        {
            IQueryable<Product> products = _productRepo.GetAll();
            if (categoryId != null)
                products = products.Where(p => p.CategoryId == categoryId);
