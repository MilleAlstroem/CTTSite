using CTTSite.Models;
using CTTSite.Models.Forms;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    // Made by Mille
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

        #region Create Room Booking
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
        #endregion

        #region Update Room Booking
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
        #endregion

        #region Delete Room Booking
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
        #endregion

        #region Get All Room Bookings
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
        #endregion

        #region Get Current Room Bookings
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
        #endregion

        #region Get Old Room Bookings
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
        #endregion

        #region Get Room Booking By ID
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
        #endregion

        #region Get Room Booking By User Email
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
        #endregion
    
        #region Check Room Booking Availability
        public bool BookingIsAvailable(RoomBooking RoomBooking)
        {
            RoomBookings = GetCurrentRoomBookings();
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if(roomBooking.ID != RoomBooking.ID)
                {
                    // If booking time slot overlaps with previous bookings
                    if (roomBooking.StartDateTime < RoomBooking.EndDateTime && roomBooking.EndDateTime > RoomBooking.StartDateTime)
                    {
                        return false;
                    }
                    continue;
                }
                // If booking StartDateTime is after booking EndDateTime
                if (RoomBooking.StartDateTime > RoomBooking.EndDateTime)
                {
                    return false;
                }
                // If booking time slot is in the past
                if (RoomBooking.StartDateTime < DateTime.Now)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Sort By Ascending
        public IEnumerable<RoomBooking> SortByAscending(List<RoomBooking> ListRoomBookings)
        {
            return from roomBooking in ListRoomBookings
                   orderby roomBooking.StartDateTime
                   select roomBooking;
        }
        #endregion

        #region Sort By Descending
        public IEnumerable<RoomBooking> SortByDescending(List<RoomBooking> ListRoomBookings)
        {
            return from roomBooking in ListRoomBookings
                   orderby roomBooking.StartDateTime descending
                   select roomBooking;
        }
        #endregion

    }
}
