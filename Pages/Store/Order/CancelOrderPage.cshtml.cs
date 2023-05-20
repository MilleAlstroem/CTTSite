using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store.Order
{
    public class CancelOrderPageModel : PageModel
    {
        private readonly IOrderService _iOrderService;
        public Models.Order Order { get; set; }

        public CancelOrderPageModel(IOrderService iOrderService)
        {
            _iOrderService = iOrderService;
        }

        public async Task OnGetAsync(int ID)
        {
            Order = await _iOrderService.GetOrderByIDAsync(ID);
        }

        public async Task<IActionResult> OnPostAsync(int ID)
        {
            await _iOrderService.CancelOrderByIDAsync(ID);
            return RedirectToPage("SpecificUserOrderPage");
        }
    }
}
