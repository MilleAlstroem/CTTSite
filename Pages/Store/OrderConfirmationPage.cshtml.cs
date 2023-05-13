using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class OrderConfirmationPageModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderConfirmationPageModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public int OrderID { get; set; }

        public async Task OnGet()
        {
            OrderID = await _orderService.GetLatestOrderFromUser(User.Identity.Name);
        }
    }
}
