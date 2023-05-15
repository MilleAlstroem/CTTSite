using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IRoomBookingService
    {
        Task CreateRoomBookingAsync(RoomBooking RoomBooking);
        Task UpdateRoomBookingAsync(RoomBooking RoomBooking);
        Task DeleteRoomBookingAsync(RoomBooking RoomBooking);
        List<RoomBooking> GetAllRoomBookings();
        RoomBooking GetRoomBookingByID(int ID);
        List<RoomBooking> GetRoomBookingsByUserID(int UserID);
        User GetUserByRoomBooking(RoomBooking roomBooking);

        // TODO: Maybe implement these methods if time permits.
        //List<RoomBooking> GetRoomBookingsWithinDateRangeAsync(DateTime StartDate, DateTime EndDate);
        //List<RoomBooking> GetRoomBookingsOutsideDateRangeAsync(DateTime StartDate, DateTime EndDate);

    }
}
