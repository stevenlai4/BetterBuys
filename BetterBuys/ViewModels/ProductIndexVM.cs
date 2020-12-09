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
        public List<SelectListItem> Types { get; set; }
        public int? TypesFilterApplied { get; set; }
    }
}
