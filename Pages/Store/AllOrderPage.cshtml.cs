using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class AllOrderPageModel : PageModel
    {
        private readonly IOrderService _orderService;
        public List<Order> Orders;
        

        public AllOrderPageModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGetAsync()
        {
            Orders = await _orderService.GetAllOrdersAsync();
        }
    }
}
