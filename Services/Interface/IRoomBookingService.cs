using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IRoomBookingService
    {
        Task<bool> CreateRoomBookingAsync(RoomBooking RoomBooking);
        Task<bool> UpdateRoomBookingAsync(RoomBooking RoomBooking);
        Task DeleteRoomBookingByIDAsync(int ID);
        Task<List<RoomBooking>> GetAllRoomBookingsAsync();
        List<RoomBooking> GetCurrentRoomBookings();
        List<RoomBooking> GetOldRoomBookings();
        RoomBooking GetRoomBookingByID(int ID);
        List<RoomBooking> GetRoomBookingsByUserEmail(string UserEmail);
        bool BookingIsAvailable(RoomBooking RoomBooking);
        IEnumerable<RoomBooking> SortByAscending(List<RoomBooking> ListRoomBookings);
        IEnumerable<RoomBooking> SortByDescending(List<RoomBooking> ListRoomBookings);

        // TODO: Maybe implement these methods if time permits.
        //List<RoomBooking> GetRoomBookingsWithinDateRangeAsync(DateTime StartDate, DateTime EndDate);
        //List<RoomBooking> GetRoomBookingsOutsideDateRangeAsync(DateTime StartDate, DateTime EndDate);

    }
}
