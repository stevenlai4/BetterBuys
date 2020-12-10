using BetterBuys.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.ViewModels
{
    public class ProductIndexVM
    {
        public List<ProductVM> Products { get; set; }
        public List<Category> Categories { get; set; }
        public int? TypesFilterApplied { get; set; }
    }
}
