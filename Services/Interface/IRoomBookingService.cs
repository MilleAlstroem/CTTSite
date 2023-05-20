using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IRoomBookingService
    {
        Task CreateRoomBookingAsync(RoomBooking RoomBooking);
        Task UpdateRoomBookingAsync(RoomBooking RoomBooking);
        Task DeleteRoomBookingByIDAsync(int ID);
        List<RoomBooking> GetAllRoomBookings();
        RoomBooking GetRoomBookingByID(int ID);
        List<RoomBooking> GetRoomBookingsByUserEmail(string UserEmail);

        // TODO: Maybe implement these methods if time permits.
        //List<RoomBooking> GetRoomBookingsWithinDateRangeAsync(DateTime StartDate, DateTime EndDate);
        //List<RoomBooking> GetRoomBookingsOutsideDateRangeAsync(DateTime StartDate, DateTime EndDate);

    }
}
