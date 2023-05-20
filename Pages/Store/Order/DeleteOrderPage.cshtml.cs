using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store.Order
{
    public class DeleteOrderPageModel : PageModel
    {
        private readonly IOrderService _orderService;

        [BindProperty]
        public Models.Order Order { get; set; } 

        public DeleteOrderPageModel(IOrderService orderService)
        {
            _orderService = orderService;
        }


        public async Task OnGetAsync(int ID)
        {
            Order = await _orderService.GetOrderByIDAsync(ID);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _orderService.DeleteOrderByOrderIDAsync(Order.ID);
            return RedirectToPage("/Store/Order/AllOrderPage");
        }
    }
}
