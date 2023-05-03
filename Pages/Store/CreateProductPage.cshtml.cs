using CTTSite.Models;
using CTTSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class CreateProductPageModel : PageModel
    {
        public IItemService ItemService;

        [BindProperty]
        public Item Item { get; set; }

        public CreateProductPageModel(IItemService iItemService)
        {
            ItemService = iItemService;
        }

        public async Task<IActionResult> OnPostAsync() 
        { 
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await ItemService.CreateItemAsync(Item);
            return RedirectToPage("AllProductsPage");
        }
    }
}
