using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit.Encodings;

namespace CTTSite.Pages.Store
{
    public class AddToCartConfirmationPageModel : PageModel
    {
        private readonly ICartItemService _iCartItemService;

        [BindProperty]
        public CartItem cartItem { get; set; }

        public AddToCartConfirmationPageModel(ICartItemService iCartItemService)
        {
            _iCartItemService = iCartItemService;
        }


        public void OnGet(int ID)
        {
            cartItem = _iCartItemService.GetCartItemByID(ID);
        }
    }
}
