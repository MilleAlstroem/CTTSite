using CTTSite.Models;
using CTTSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class UpdateProductPageModel : PageModel
    {
        public IItemService IItemService;

        [BindProperty]
        public Item Item { get; set; }

        public UpdateProductPageModel(IItemService iItemService)
        {
            IItemService = iItemService;
        }

        public async Task<IActionResult> OnGetAsync(int ID)
        {
            Item = await IItemService.GetItemByIDAsync(ID);
            if (Item == null)
            {
                return RedirectToPage("AllProductsPage");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() 
        { 
            if(!ModelState.IsValid) 
            {
                return Page();
            }
            await IItemService.UpdateItemAsync(Item);
            return RedirectToPage("AllProductsPage");
        }
    }
}
