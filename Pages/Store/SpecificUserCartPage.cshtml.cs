using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class SpecificUserCartPageModel : PageModel
    {
        public ICartItemService ICartItemService;
        public IUserService IUserService;
        public List<CartItem> CartItems { get; set; }

        public SpecificUserCartPageModel(ICartItemService iCartItemService, IUserService iUserService)
        {
            ICartItemService = iCartItemService;
            IUserService = iUserService;
        }

        public IActionResult OnGet()
        {
            Models.User CurrentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            CartItems = ICartItemService.GetAllCartItemsByUserID(CurrentUser.Id);
            return Page();
        }

    }
}
