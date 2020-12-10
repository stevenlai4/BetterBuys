using BetterBuys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Data
{
    public class StoreDbSeeder
    {
        public static async Task SeedAsync(StoreDbContext db)
        {
            if (!await db.Categories.AnyAsync())
            {
                await db.Categories.AddRangeAsync(GetPreconfiguredCategories());
                await db.SaveChangesAsync();
            }

            if (!await db.Products.AnyAsync())
            {
                await db.Products.AddRangeAsync(GetPreconfiguredProducts());
                await db.SaveChangesAsync();
            }

            if(!await db.ProductCategories.AnyAsync())
            {
                await db.ProductCategories.AddRangeAsync(GetPreconfiguredProductCategories());
                await db.SaveChangesAsync();
            }
        }

        static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product(".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5m,  "/images/products/1.png"),
                new Product(".NET Black & White Mug", ".NET Black & White Mug", 8.50m, "/images/products/2.png"),
                new Product("Prism White T-Shirt", "Prism White T-Shirt", 12m,  "/images/products/3.png"),
                new Product(".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12m, "/images/products/4.png"),
                new Product("Roslyn Red Sheet", "Roslyn Red Sheet", 8.5m, "/images/products/5.png"),
                new Product(".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12m, "/images/products/6.png"),
                new Product("Roslyn Red T-Shirt", "Roslyn Red T-Shirt",  12m, "/images/products/7.png"),
                new Product("Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5m, "/images/products/8.png"),
                new Product("Cup<T> White Mug", "Cup<T> White Mug", 12m, "/images/products/9.png"),
                new Product(".NET Foundation Sheet", ".NET Foundation Sheet", 12m, "/images/products/10.png"),
                new Product("Cup<T> Sheet", "Cup<T> Sheet", 8.5m, "/images/products/11.png"),
                new Product("Prism White TShirt", "Prism White TShirt", 12m, "/images/products/12.png")
            };
        }

        static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new Category("Mug"),
                new Category("T-Shirt"),
                new Category("Sheet"),
                new Category("USB Memory Stick")
            };
        }

        static IEnumerable<ProductCategory> GetPreconfiguredProductCategories()
        {
            return new List<ProductCategory>
            {
                new ProductCategory(2,1),
                new ProductCategory(1,2),
                new ProductCategory(2,3),
                new ProductCategory(2,4),
                new ProductCategory(3,5),
                new ProductCategory(2,6),
                new ProductCategory(2,7),
                new ProductCategory(2,8),
                new ProductCategory(1,9),
                new ProductCategory(3,10),
                new ProductCategory(3,11),
                new ProductCategory(2,12)
            };
        }
    }
}
