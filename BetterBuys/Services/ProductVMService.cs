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

        public ProductIndexVM GetProductsVM(int? categoryId, int? cartId)
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
                    Quantity = cartId != null ? (from cp in _db.CartProducts where cp.ProductId == p.Id && cp.CartId == cartId select cp.Quantity).FirstOrDefault() : 0
                }).ToList(),
                Categories = categories.Select(c => new CategoryVM
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            };
            return vm;
        }

        public ProductVM GetProduct (int productId)
        {
            Product product = _productRepo.GetOne(productId);
            ProductVM productVM = new ProductVM();
            productVM.Id = product.Id;
            productVM.Name = product.Name;
            productVM.Price = product.Price;
            productVM.ImageUri = product.ImageUri;

            return productVM;
        }
    }
}
