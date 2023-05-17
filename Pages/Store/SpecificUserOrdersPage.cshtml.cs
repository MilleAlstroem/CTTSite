using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class SpecificUserOrdersPageModel : PageModel
    {
        public IOrderService IOrderService { get; set; }
        public IUserService IUserService { get; set; }
        public List<Order> Orders { get; set; }


        public SpecificUserOrdersPageModel(IOrderService iOrderService, IUserService iUserService)
        {
            IOrderService = iOrderService;
            IUserService = iUserService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Models.User CurrentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            Orders = await IOrderService.GetOrdersByUserIDAsync(CurrentUser.Id);
            return Page();
        }
    }
}
