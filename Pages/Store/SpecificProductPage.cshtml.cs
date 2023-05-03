using CTTSite.Models;
using CTTSite.Pages.User.LogIn;
using CTTSite.Services;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class SpecificProductPageModel : PageModel
    {
        public IItemService IItemService;
        public ICartItemService ICartItemService;

        [BindProperty]
        public Item Item { get; set; }

        [BindProperty]
        public CartItem CartItem { get; set; }

        public SpecificProductPageModel(IItemService iItemService, ICartItemService iCartService)
        {
            IItemService = iItemService;
            ICartItemService = iCartService;
        }

        public void OnGet(int ID)
        {
            Item = IItemService.GetItemByID(ID);
        }

        //public async Task<IActionResult> OnPostAsync(int ID)
        //{
        //    await ICartItemService.AddToCartAsync(new CartItem(6, Item.ID, CartItem.Amount, LogInPageModel.LoggedInUser.Id, false));
        //    return Page();
        //}

        public IActionResult OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            CartItem = new CartItem(6, Item.ID, CartItem.Amount, 2, false);
            ICartItemService.AddToCartAsync(CartItem);
            return Page();
        }
    }
}
