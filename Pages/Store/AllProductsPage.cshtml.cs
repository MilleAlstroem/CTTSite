using CTTSite.Models;
using CTTSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class AllProductsPageModel : PageModel
    {
        public IItemService ItemService;
        public List<Item> Items;

        public AllProductsPageModel(IItemService iItemService)
        {
            ItemService = iItemService;
        }

        public async Task OnGetAsync()
        {
            Items = await ItemService.GetAllItemsAsync();
        }
    }
}
