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

        [BindProperty]
        public List<CartItem> CartItems { get; set; }
        public int CartItemsCount { get; set; }
        public decimal TotalPrice { get; set; }

        public SpecificUserCartPageModel(ICartItemService iCartItemService, IUserService iUserService)
        {
            ICartItemService = iCartItemService;
            IUserService = iUserService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Models.User currentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            CartItems = await ICartItemService.GetAllCartItemsByUserIDAsync(currentUser.Id);
            TotalPrice = await ICartItemService.GetTotalPriceOfCartByUserIDAsync(currentUser.Id);
            CartItemsCount = CartItems.Count;
            return Page();
        }


    }
}
