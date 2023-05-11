using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class DeleteCartItemPageModel : PageModel
    {
        public ICartItemService ICartItemService;
        public IUserService IUserService;

        [BindProperty]
        public CartItem CartItem { get; set; }

        public DeleteCartItemPageModel(ICartItemService iCartItemService, IUserService iUserService)
        {
            ICartItemService = iCartItemService;
            IUserService = iUserService;
        }

        public void OnGet(int ID)
        {
            CartItem = ICartItemService.GetCartItemByID(ID);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await ICartItemService.RemoveFromCartByIDAsync(CartItem.ID);
            return RedirectToPage("SpecificUserCartPage"); 
        }
    }
}
