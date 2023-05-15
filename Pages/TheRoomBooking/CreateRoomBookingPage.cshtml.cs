using CTTSite.Models;
using CTTSite.Services;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.TheRoomBooking
{
    public class CreateRoomBookingPageModel : PageModel
    {
        public IRoomBookingService IRoomBookingService { get; set; }
        public IUserService IUserService { get; set; }

        [BindProperty]
        public RoomBooking RoomBooking { get; set; }
        
        public CreateRoomBookingPageModel(IRoomBookingService iRoomBookingService, IUserService iUserService)
        {
            IRoomBookingService = iRoomBookingService;
            IUserService = iUserService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RoomBooking.UserID = IUserService.GetUserByEmail(HttpContext.User.Identity.Name).Id;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await IRoomBookingService.CreateRoomBookingAsync(RoomBooking);
            return RedirectToPage("/TheRoomBooking/AllRoomBookingsPage");
        }

    }
}
