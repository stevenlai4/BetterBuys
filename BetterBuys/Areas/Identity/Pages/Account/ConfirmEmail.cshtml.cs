using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterBuys.Interfaces;
using BetterBuys.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace BetterBuys.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProductVMService _productVMService;

        public ConfirmEmailModel(UserManager<IdentityUser> userManager, IProductVMService productVMService)
        {
            _userManager = userManager;
            _productVMService = productVMService;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public ProductIndexVM ProductIndex { get; set; } = new ProductIndexVM();

        public async Task<IActionResult> OnGetAsync(string userId, string code, int? categoryId)
        {
            ProductIndex = _productVMService.GetProductsVM(HttpContext, categoryId);

            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return Page();
        }
    }
}
