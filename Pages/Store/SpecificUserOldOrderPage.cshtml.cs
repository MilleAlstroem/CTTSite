using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class SpecificUserOldOrderPageModel : PageModel
    {
        public IUserService IUserService;
        public IOrderService IOrderService;

        [BindProperty]
        public Order Order { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public SpecificUserOldOrderPageModel(IUserService iUserService, IOrderService iOrderService)
        {
            IUserService = iUserService;
            IOrderService = iOrderService;
        }

        public IActionResult OnGet(int ID)
        {
            Models.User CurrentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            Order = IOrderService.GetOrderByID(ID);
            CartItems = IOrderService.GetOldOrderByOrderID(ID).Result;
            return Page();
            //if (Order.UserID == CurrentUser.Id)
            //{
            //    CartItems = IOrderService.GetOldOrderByOrderID(ID).Result;
            //    return Page();
            //}
            //else
            //{
            //    return RedirectToPage("/Store/SpecificUserOrdersPage");
            //}
        }
    }
}
