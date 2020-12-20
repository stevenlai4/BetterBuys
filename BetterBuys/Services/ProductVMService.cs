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
        public ProductIndexVM VM = new ProductIndexVM();
        public ProductVMService(IBaseRepository<Product> productRepo, IBaseRepository<Category> categoryRepo, StoreDbContext db)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _db = db;
        }

        public ProductIndexVM GetProductsVM(HttpContext context, int? categoryId)
        {
            List<Product> products = _productRepo.GetAll().ToList();
            List<Category> categories = _categoryRepo.GetAll().ToList();

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
                            select p).ToList();
            }

            var vm = new ProductIndexVM()
            {
                Products = products.Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUri = p.ImageUri,
                    Description = p.Description,
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

        public ProductVM GetProduct(int productId)
        {
            Product product = _productRepo.GetOne(productId);
            ProductVM productVM = new ProductVM();
            productVM.Id = product.Id;
            productVM.Name = product.Name;
            productVM.Price = product.Price;
            productVM.ImageUri = product.ImageUri;
            productVM.Description = product.Description;

            return productVM;
        }

        public ProductIndexVM GetProductsVMFilteredSorted(HttpContext context, int? categoryId, string searchString, string sortOption)
        {
            List<Product> products = _productRepo.GetAll().ToList();
            List<Category> categories = _categoryRepo.GetAll().ToList();

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
                            select p).ToList();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                products = (from p in products
                            where p.Name.ToLower().Contains(searchString.ToLower())                            
                            select p).ToList();
            }


            if (sortOption == "highToLow")
            {

                products = (from p in products
                            orderby p.Price descending
                            select p).ToList();
            }
            
            if (sortOption == "lowToHigh")
            {

                products = (from p in products
                            orderby p.Price 
                            select p).ToList();
            }

            VM.Products = products.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUri = p.ImageUri,
                Description = p.Description,
                Quantity = cartId != null ? (from cp in _db.CartProducts where cp.ProductId == p.Id && cp.CartId == cartId select cp.Quantity).FirstOrDefault() : 0
            }).ToList();
            VM.Categories = categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            VM.TotalQuantity = total;

            return VM;
        }
    }
}
