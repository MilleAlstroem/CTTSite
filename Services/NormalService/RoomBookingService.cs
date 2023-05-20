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
        public IUserService IUserService;
        public List<RoomBooking> RoomBookings;

        public RoomBookingService(DBServiceGeneric<RoomBooking> dBServiceGeneric, IUserService iUserService)
        {
            DBServiceGeneric = dBServiceGeneric;
            IUserService = iUserService;
            RoomBookings = GetAllRoomBookingsAsync().Result;
        }


        public async Task<bool> CreateRoomBookingAsync(RoomBooking RoomBooking)
        {
            if (BookingIsAvailable(RoomBooking))
            {
                RoomBookings.Add(RoomBooking);
                await DBServiceGeneric.AddObjectAsync(RoomBooking);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRoomBookingAsync(RoomBooking NewRoomBooking)
        {
            RoomBookings = GetAllRoomBookingsAsync().Result;
            if (NewRoomBooking != null)
            {
                foreach (RoomBooking OldRoomBooking in RoomBookings)
                {
                    if (OldRoomBooking.ID == NewRoomBooking.ID)
                    {
                        if(BookingIsAvailable(NewRoomBooking))
                        {
                            OldRoomBooking.StartDateTime = NewRoomBooking.StartDateTime;
                            OldRoomBooking.EndDateTime = NewRoomBooking.EndDateTime;
                            OldRoomBooking.Description = NewRoomBooking.Description;
                            OldRoomBooking.UserEmail = NewRoomBooking.UserEmail;

                            await DBServiceGeneric.UpdateObjectAsync(OldRoomBooking);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public async Task DeleteRoomBookingByIDAsync(int ID)
        {
            RoomBookings = GetAllRoomBookingsAsync().Result;
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.ID == ID)
                {
                    RoomBookings.Remove(roomBooking);
                    await DBServiceGeneric.DeleteObjectAsync(roomBooking);
                    break;
                }
            }
        }

        public async Task<List<RoomBooking>> GetAllRoomBookingsAsync()
        {
            foreach (RoomBooking roomBooking in DBServiceGeneric.GetObjectsAsync().Result.ToList())
            {
                if (roomBooking.EndDateTime.AddMonths(1) < DateTime.Now)
                {
                    await DBServiceGeneric.DeleteObjectAsync(roomBooking);
                }
            }
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
        }

        public List<RoomBooking> GetCurrentRoomBookings()
        {
            List<RoomBooking> CurrentRoomBookings = new List<RoomBooking>();
            foreach (RoomBooking roomBooking in GetAllRoomBookingsAsync().Result)
            {
                if (roomBooking.EndDateTime > DateTime.Now)
                {
                    CurrentRoomBookings.Add(roomBooking);
                }
            }
            return CurrentRoomBookings;
        }

        public List<RoomBooking> GetOldRoomBookings() 
        { 
            List<RoomBooking> OldRoomBookings = new List<RoomBooking>();
            foreach (RoomBooking roomBooking in GetAllRoomBookingsAsync().Result)
            {
                if (roomBooking.EndDateTime < DateTime.Now)
                {
                    OldRoomBookings.Add(roomBooking);
                }
            }
            return OldRoomBookings;
        }

        public RoomBooking GetRoomBookingByID(int ID)
        {
            RoomBookings = GetAllRoomBookingsAsync().Result;
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.ID == ID)
                {
                    return roomBooking;
                }
            }
            return null;
        }

        public List<RoomBooking> GetRoomBookingsByUserEmail(string UserEmail)
        {
            RoomBookings = GetCurrentRoomBookings();
            List<RoomBooking> UserRoomBookings = new List<RoomBooking>();
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.UserEmail == UserEmail)
                {
                    UserRoomBookings.Add(roomBooking);
                }
            }
            return UserRoomBookings;
        }
    
        public bool BookingIsAvailable(RoomBooking RoomBooking)
        {
            RoomBookings = GetAllRoomBookingsAsync().Result;
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.ID != RoomBooking.ID)
                {
                    // If booking time slot overlaps with previous bookings
                    if (roomBooking.StartDateTime < RoomBooking.EndDateTime && roomBooking.EndDateTime > RoomBooking.StartDateTime)
                    {
                        return false;
                    }
                    // If booking StartDateTime is after booking EndDateTime
                    if (roomBooking.StartDateTime > roomBooking.EndDateTime)
                    {
                        return false;
                    }
                    // If booking time slot is in the past
                    if (roomBooking.StartDateTime < DateTime.Now)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public IEnumerable<RoomBooking> SortByAscending(List<RoomBooking> ListRoomBookings)
        {
            return from roomBooking in ListRoomBookings
                   orderby roomBooking.StartDateTime
                   select roomBooking;
        }

        public IEnumerable<RoomBooking> SortByDescending(List<RoomBooking> ListRoomBookings)
        {
            return from roomBooking in ListRoomBookings
                   orderby roomBooking.StartDateTime descending
                   select roomBooking;
        }

    }
}
