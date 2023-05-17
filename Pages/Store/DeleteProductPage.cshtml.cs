using CTTSite.Models;
using CTTSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class DeleteProductPageModel : PageModel
    {
        public IItemService IItemService;

        [BindProperty]
        public Item Item { get; set; }

        public DeleteProductPageModel(IItemService iItemService)
        {
            IItemService = iItemService;
        }

        public async Task OnGet(int ID)
        {
            Item = await IItemService.GetItemByIDAsync(ID);
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            await IItemService.DeleteItemByIDAsync(Item.ID);
            return RedirectToPage("AllProductsPage");
        }
    }
}
