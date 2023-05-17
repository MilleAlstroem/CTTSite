using CTTSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store.Product
{
    public class AdminProductsPageModel : PageModel
    {
        private readonly IItemService _itemService;
        public List<Models.Item> Items;

        public AdminProductsPageModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task OnGetAsync()
        {
            Items = await _itemService.GetAllItemsAsync();
        }
    }
}
