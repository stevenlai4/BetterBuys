using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Services
{
    public class ProductVMService : IProductVMService
    {
        private readonly IBaseRepository<Product> _productRepo;
        private readonly IBaseRepository<Category> _categoryRepo;
        private readonly StoreDbContext _db;

        public ProductVMService(IBaseRepository<Product> productRepo, IBaseRepository<Category> categoryRepo, StoreDbContext db)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _db = db;
        }

        public ProductIndexVM GetProductsVM(int? categoryId)
        {
            IQueryable<Product> products = _productRepo.GetAll();
            IQueryable<Category> categories = _categoryRepo.GetAll();
            if (categoryId != null)
            {
                products = from c in categories
                           join pc in _db.ProductCategories on c.Id equals pc.CategoryId
                           join p in products on pc.ProductId equals p.Id
                           where c.Id == categoryId
                           select new Product(p.Name, p.Description, p.Price, p.ImageUri);
            }
                

            var vm = new ProductIndexVM()
            {
                Products = products.Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUri = p.ImageUri,
                    
                }).ToList(),
               Categories = GetCategories().ToList()
            };
            return vm;
        }
        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = _categoryRepo.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).OrderBy(t => t.Text).ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            categories.Insert(0, allItem);

            return categories;
        }
    }
}
