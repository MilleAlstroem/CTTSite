using CTTSite.Models;
using CTTSite.Services;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.TheRoomBooking
{
    // Made by Mille
    public class CreateRoomBookingPageModel : PageModel
    {
        public IRoomBookingService IRoomBookingService { get; set; }

        [BindProperty]
        public RoomBooking RoomBooking { get; set; }
        
        public string Message { get; set; }

        public CreateRoomBookingPageModel(IRoomBookingService iRoomBookingService)
        {
            IRoomBookingService = iRoomBookingService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {
            RoomBooking.UserEmail = HttpContext.User.Identity.Name;
            if((RoomBooking != null) && (RoomBooking.Description != null))
            {
				if (IRoomBookingService.CreateRoomBookingAsync(RoomBooking).Result == true)
				{
					return RedirectToPage("/TheRoomBooking/AllRoomBookingsPage");
				}
				else
				{
					Message = "Booking time slot is not available";
					return Page();
				}
			}
            else
            {
                Message = "Please fill out the booking";
				return Page();
			}
        }

    }
}
