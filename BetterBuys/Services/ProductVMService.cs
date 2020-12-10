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

        public ProductVMService(IBaseRepository<Product> productRepo, IBaseRepository<Category> categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public ProductIndexVM GetProductsVM(int? categoryId)
        {
            IQueryable<Product> products = _productRepo.GetAll();
            IQueryable<Category> categories = _categoryRepo.GetAll();

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
                    Name = c.Name
                }).ToList()
            };
            return vm;
        }

        //public List<CategoryVM> GetCategories()
        //{
        //    var categories = _categoryRepo.GetAll().Select(c => new CategoryVM
        //    { 
        //        Name = c.Name
        //    }).ToList();
        //    return categories;
        //}
    }
}
