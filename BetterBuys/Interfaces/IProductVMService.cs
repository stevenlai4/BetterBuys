using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Interfaces
{
    public interface IProductVMService
    {
    ProductIndexVM GetProductsVM(int? categoryId);
    IEnumerable<SelectListItem> GetCategories();
    }
}
