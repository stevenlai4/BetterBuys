using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                products = (from p in products
                            join pc in _db.ProductCategories on p.Id equals pc.ProductId
                            join c in categories on pc.CategoryId equals c.Id
                            where c.Id == categoryId
                            select p);
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
                Categories = categories.Select(c => new CategoryVM
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            };
            return vm;
        }

        public ProductVM GetProductVM (int productId)
        {
            ProductVM product = _productRepo.GetOne(productId);

            return product;
     
        }
    }
}
