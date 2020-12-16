using BetterBuys.Data;
using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Http;
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

        public ProductIndexVM GetProductsVM(HttpContext context, int? categoryId)
        {
            IQueryable<Product> products = _productRepo.GetAll();
            IQueryable<Category> categories = _categoryRepo.GetAll();

            int? cartId = context.Session.GetInt32("cartId");

            int total = 0;

            if (cartId != null)
            {
                foreach (var p in products)
                {
                    total += (from cp in _db.CartProducts where cp.ProductId == p.Id && cp.CartId == cartId select cp.Quantity).FirstOrDefault();
                }
            }

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
                }).ToList(),
                TotalQuantity = total
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

        public ProductIndexVM GetProductsVMFilteredSorted(int? categoryId, string searchString, string sortOption)
        {
            IQueryable<Product> products = _productRepo.GetAll();
            IQueryable<Category> categories = _categoryRepo.GetAll();
            
            int total = 0;

           
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
                    ImageUri = p.ImageUri                   
                }).ToList(),
                Categories = categories.Select(c => new CategoryVM
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                TotalQuantity = total
            };
            return vm;
        }
    }
}
