using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.TheRoomBooking
{
    public class DeleteRoomBookingPageModel : PageModel
    {
        public IRoomBookingService IRoomBookingService { get; set; }
        public IUserService IUserService { get; set; }

        [BindProperty]
        public RoomBooking RoomBooking { get; set; }

        public DeleteRoomBookingPageModel(IRoomBookingService iRoomBookingService, IUserService iUserService)
        {
            IRoomBookingService = iRoomBookingService;
            IUserService=iUserService;
        }

        public void OnGet(int ID)
        {
            RoomBooking = IRoomBookingService.GetRoomBookingByID(ID);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await IRoomBookingService.DeleteRoomBookingAsync(RoomBooking);
            return RedirectToPage("/TheRoomBooking/AllRoomBookingsPage");
        }
    }
}
