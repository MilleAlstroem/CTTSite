using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class RoomBookingService : IRoomBookingService
    {

        public DBServiceGeneric<RoomBooking> DBServiceGeneric;
        public JsonFileService<RoomBooking> JsonFileService;
        public List<RoomBooking> RoomBookings;

        public RoomBookingService(DBServiceGeneric<RoomBooking> dBServiceGeneric, JsonFileService<RoomBooking> jsonFileService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            RoomBookings = GetAllRoomBookings();
        }
        

        public Task CreateRoomBookingAsync(RoomBooking RoomBooking)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoomBookingAsync(RoomBooking RoomBooking)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoomBookingAsync(RoomBooking RoomBooking)
        {
            throw new NotImplementedException();
        }

        public List<RoomBooking> GetAllRoomBookings()
        {
            //return JsonFileService.GetJsonObjects().ToList();
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
        }

        public RoomBooking GetRoomBookingByID(int ID)
        {
            foreach(RoomBooking roomBooking in RoomBookings)
            {
                if(roomBooking.ID == ID)
                {
                    return roomBooking; 
                }
            }
            return null;
        }

        public List<RoomBooking> GetRoomBookingsByUserID(int UserID)
        {
            List<RoomBooking> userRoomBookings = new List<RoomBooking>();
            foreach(RoomBooking roomBooking in RoomBookings)
            {
                if(roomBooking.User.Id == UserID)
                {
                    userRoomBookings.Add(roomBooking);
                }
            }
            return userRoomBookings;
        }

    }
}
