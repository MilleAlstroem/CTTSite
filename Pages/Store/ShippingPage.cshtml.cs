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
        public ShippingInfo ShippingInfo { get; set; } = new ShippingInfo();

        public ShippingPageModel(IShippingInfoService iShippingInfoService, IUserService iUserService)
        {
            IShippingInfoService = iShippingInfoService;
            IUserService = iUserService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Models.User CurrentUser = IUserService.GetUserByEmail(HttpContext.User.Identity.Name);
            ShippingInfo.UserID = CurrentUser.Id;
            ShippingInfo.SubmissionDate = DateTime.Now;
            IShippingInfoService.CreateShippingInfo(ShippingInfo);
            return RedirectToPage("SpecificUserCartPage");
        }
    }
}