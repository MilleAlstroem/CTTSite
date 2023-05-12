using CTTSite.Models;
using CTTSite.Pages.User.LogIn;
using CTTSite.Services;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CTTSite.Pages.Store
{
    public class SpecificProductPageModel : PageModel
    {
        public IItemService IItemService;
        public ICartItemService ICartItemService;
        public IUserService IUserService;

        [BindProperty]
        public Item Item { get; set; }

        public CartItem CartItem { get; set; } = new CartItem();

        public Models.User User { get; set; }

        [BindProperty]
        [Range(1, 10)]
        public int Count { get; set; }

        public SpecificProductPageModel(IItemService iItemService, ICartItemService iCartService, IUserService iUserService)
        {
            IItemService = iItemService;
            ICartItemService = iCartService;
            IUserService = iUserService;
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

        public async Task<IActionResult> OnPostAsync(int ID)
        {
            Item = IItemService.GetItemByID(ID);
            User = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);

            CartItem.ItemID = ID;
            CartItem.Amount = Count;
            CartItem.UserID = User.Id;
            CartItem.Paid = false;

            await ICartItemService.AddToCartAsync(CartItem);
            return RedirectToPage("SpecificProductPage", Item.ID);
        }
    }
}
