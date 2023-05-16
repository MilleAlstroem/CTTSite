using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class CancelOrderPageModel : PageModel
    {
        private readonly IOrderService _iOrderService;
        public Order Order { get; set; }

        public CancelOrderPageModel(IOrderService iOrderService)
        {
            _iOrderService = iOrderService;
        }

        public void OnGet(int ID)
        {
            Order = _iOrderService.GetOrderByID(ID);
        }

        public async Task<IActionResult> OnPostAsync(int ID)
        {
            Order = _iOrderService.GetOrderByID(ID);
            await _iOrderService.CreateOrderAsync(Order);
            return RedirectToPage("SpecificUserOrdersPage");
        }
    }
}
