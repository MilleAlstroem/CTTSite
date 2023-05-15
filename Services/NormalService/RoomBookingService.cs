using CTTSite.Models;
using CTTSite.Models.Forms;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class RoomBookingService : IRoomBookingService
    {

        public DBServiceGeneric<RoomBooking> DBServiceGeneric;
        public JsonFileService<RoomBooking> JsonFileService;
        public IUserService IUserService;
        public List<RoomBooking> RoomBookings;

        public RoomBookingService(DBServiceGeneric<RoomBooking> dBServiceGeneric, JsonFileService<RoomBooking> jsonFileService, IUserService iUserService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            IUserService = iUserService;
            RoomBookings = GetAllRoomBookings();
        }


        public async Task CreateRoomBookingAsync(RoomBooking RoomBooking)
        {
            await DBServiceGeneric.AddObjectAsync(RoomBooking);
        }

        public Task UpdateRoomBookingAsync(RoomBooking RoomBooking)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRoomBookingAsync(RoomBooking RoomBooking)
        {
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking == RoomBooking)
                {
                    RoomBookings.Remove(roomBooking);
                }
            }
            await DBServiceGeneric.SaveObjectsAsync(RoomBookings);
        }

        public List<RoomBooking> GetAllRoomBookings()
        {
            //return JsonFileService.GetJsonObjects().ToList();
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
        }

        public RoomBooking GetRoomBookingByID(int ID)
        {
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.ID == ID)
                {
                    return roomBooking;
                }
            }
            return null;
        }

        public List<RoomBooking> GetRoomBookingsByUserID(int UserID)
        {
            List<RoomBooking> UserRoomBookings = new List<RoomBooking>();
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.UserID == UserID)
                {
                    UserRoomBookings.Add(roomBooking);
                }
            }
            return UserRoomBookings;
        }

        public User GetUserByRoomBooking(RoomBooking roomBooking)
        {
            return IUserService.GetUserByID(roomBooking.UserID);
        }
    
    }
}
