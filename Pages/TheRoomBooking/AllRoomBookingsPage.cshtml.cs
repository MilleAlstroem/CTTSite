using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.TheRoomBooking
{
    public class AllRoomBookingsPageModel : PageModel
    {
        public IRoomBookingService IRoomBookingService { get; set; }
        public IUserService IUserService { get; set; }
        public List<RoomBooking> RoomBookings { get; set; }

        public AllRoomBookingsPageModel(IRoomBookingService iRoomBookingService, IUserService iUserService)
        {
            IRoomBookingService = iRoomBookingService;
            IUserService = iUserService;
        }

        public void OnGet()
        {
            RoomBookings = IRoomBookingService.GetAllRoomBookings();
        }

    }
}
