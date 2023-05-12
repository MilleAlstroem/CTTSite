using CTTSite.Models;
using CTTSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CTTSite.Pages.Store
{
    public class CreateProductPageModel : PageModel
    {
        private readonly IItemService _itemService;

        [BindProperty]
        public Item Item { get; set; }

        public CreateProductPageModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _itemService.CreateItemAsync(Item);

            return RedirectToPage("AllProductsPage");
        }
    }
}