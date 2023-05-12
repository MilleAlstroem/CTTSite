using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class ShippingPageModel : PageModel
    {
        public IShippingInfoService IShippingInfoService;
        public IUserService IUserService;
        public ICartItemService ICartItemService;
        public IOrderService IOrderService;

        [BindProperty]
        public ShippingInfo ShippingInfo { get; set; } = new ShippingInfo();

        [BindProperty]
        public Order order { get; set; } = new Order();

        public List<CartItem> CartItems { get; set; }

        public ShippingPageModel(IShippingInfoService iShippingInfoService, IUserService iUserService, ICartItemService iCartItemService, IOrderService iOrderService)
        {
            IShippingInfoService = iShippingInfoService;
            IUserService = iUserService;
            ICartItemService=iCartItemService;
            IOrderService = iOrderService;
        }

        public void OnGet()
        {
            Models.User CurrentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            CartItems = ICartItemService.GetAllCartItemsByUserID(CurrentUser.Id);
        }

        public IActionResult OnPostCreateOrder()
        {
            Models.User CurrentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            ShippingInfo.UserID = CurrentUser.Id;
            ShippingInfo.SubmissionDate = DateTime.Now;
            IShippingInfoService.CreateShippingInfo(ShippingInfo);
            order.UserID = CurrentUser.Id;
            order.Shipped = false;
            order.Cancelled = false;
            order.TotalPrice = ICartItemService.GetTotalPriceOfCartByUserID(CurrentUser.Id);
            IOrderService.CreateOrderAsync(order);
            IOrderService.AddCartItemsToOrder(CurrentUser.Id);
            ICartItemService.ConvertBoolPaidByUserIDAsync(CurrentUser.Id);
            return RedirectToPage("/Store/OrderConfirmationPage");
        }
    }
}