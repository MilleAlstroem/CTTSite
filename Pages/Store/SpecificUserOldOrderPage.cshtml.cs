using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> OnGetAsync(int ID)
        {
            Models.User CurrentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            Order = IOrderService.GetOrderByID(ID);
            CartItems = await IOrderService.GetOldOrderByOrderIDAsync(ID);
            return Page();
        }
    }
}