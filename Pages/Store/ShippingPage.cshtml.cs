using CTTSite.Models;
using CTTSite.Services;
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
        public IItemService IItemService;

        [BindProperty]
        public ShippingInfo ShippingInfo { get; set; } = new ShippingInfo();

        [BindProperty]
        public Order order { get; set; } = new Order();

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public ShippingPageModel(IShippingInfoService iShippingInfoService, IUserService iUserService, ICartItemService iCartItemService, IOrderService iOrderService)
        {
            IShippingInfoService = iShippingInfoService;
            IUserService = iUserService;
            ICartItemService=iCartItemService;
            IOrderService = iOrderService;
        }

        public async Task OnGetAsync()
        {
            Models.User currentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            CartItems = await ICartItemService.GetAllCartItemsByUserIDAsync(currentUser.Id);
        }


        public async Task<IActionResult> OnPostCreateOrderAsync()
        {
            Models.User currentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            ShippingInfo.UserID = currentUser.Id;
            ShippingInfo.SubmissionDate = DateTime.Now;
            IShippingInfoService.CreateShippingInfo(ShippingInfo);
            order.UserID = currentUser.Id;
            order.Shipped = false;
            order.Cancelled = false;
            order.TotalPrice = await ICartItemService.GetTotalPriceOfCartByUserIDAsync(currentUser.Id);
            await IOrderService.CreateOrderAsync(order);

            foreach (CartItem cartItem in CartItems)
            {
                await IItemService.UpdateItemQuantityByIDAsync(cartItem.ItemID, cartItem.Quantity);
            }

            await IOrderService.AddCartItemsToOrderAsync(currentUser.Id);
            await ICartItemService.ConvertBoolPaidByUserIDAsync(currentUser.Id);

            return RedirectToPage("/Store/OrderConfirmationPage");
        }
    }
}