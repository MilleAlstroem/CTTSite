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
        /// <summary>
        /// This method creates a RoomBooking and adds it to the DB by first checking if the booking is available with the BookingIsAvailable method.
        /// </summary>
        /// <param name="roomBooking"></param>
        /// <returns></returns>
        public async Task<bool> CreateRoomBookingAsync(RoomBooking roomBooking)
        {
            if (BookingIsAvailable(roomBooking))
            {
                RoomBookings.Add(roomBooking);
                await DBServiceGeneric.AddObjectAsync(roomBooking);
                return true;
            }
            return false;
        }
        #endregion

        #region Update Room Booking
        /// <summary>
        /// This method updates a RoomBooking and saves it to the DB by checking if the updated RoomBooking is available with the BookingIsAvailable method.
        /// </summary>
        /// <param name="newRoomBooking"></param>
        /// <returns></returns>
        public async Task<bool> UpdateRoomBookingAsync(RoomBooking newRoomBooking)
        {
            RoomBookings = await GetAllRoomBookingsAsync();
            if (newRoomBooking != null)
            {
                foreach (RoomBooking OldRoomBooking in RoomBookings)
                {
                    if (OldRoomBooking.ID == newRoomBooking.ID)
                    {
                        if(BookingIsAvailable(newRoomBooking))
                        {
                            OldRoomBooking.StartDateTime = newRoomBooking.StartDateTime;
                            OldRoomBooking.EndDateTime = newRoomBooking.EndDateTime;
                            OldRoomBooking.Description = newRoomBooking.Description;
                            OldRoomBooking.UserEmail = newRoomBooking.UserEmail;

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
        /// <summary>
        /// This method deletes a RoomBooking from the DB by first getting all RoomBookings and then removing the RoomBooking with the matching ID.
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public async Task DeleteRoomBookingByIDAsync(int iD)
        {
            RoomBookings = await GetAllRoomBookingsAsync();
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.ID == iD)
                {
                    RoomBookings.Remove(roomBooking);
                    await DBServiceGeneric.DeleteObjectAsync(roomBooking);
                    break;
                }
            }
        }
        #endregion

        #region Get All Room Bookings
        /// <summary>
        /// This method gets all RoomBookings from the DB and removes all RoomBookings that are more than a month old.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// This method gets all RoomBookings that are not older than the current date and time.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// This method gets all RoomBookings that are older than the current date and time.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// This method gets a RoomBooking from DB by ID.
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public RoomBooking GetRoomBookingByID(int iD)
        {
            RoomBookings = GetAllRoomBookingsAsync().Result;
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.ID == iD)
                {
                    return roomBooking;
                }
            }
            return null;
        }
        #endregion

        #region Get Room Booking By User Email
        /// <summary>
        /// This method gets all RoomBookings of a specific user from DB by UserEmail.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public List<RoomBooking> GetRoomBookingsByUserEmail(string userEmail)
        {
            RoomBookings = GetCurrentRoomBookings();
            List<RoomBooking> UserRoomBookings = new List<RoomBooking>();
            foreach (RoomBooking roomBooking in RoomBookings)
            {
                if (roomBooking.UserEmail == userEmail)
                {
                    UserRoomBookings.Add(roomBooking);
                }
            }
            return UserRoomBookings;
        }
        #endregion
    
        #region Check Room Booking Availability
        /// <summary>
        /// This method checks if a RoomBooking is available by checking if the time slot overlaps with previous bookings, 
        /// if the StartDateTime is after the EndDateTime and if the time slot is in the past.
        /// </summary>
        /// <param name="roomBooking"></param>
        /// <returns></returns>
        public bool BookingIsAvailable(RoomBooking roomBooking)
        {
            RoomBookings = GetCurrentRoomBookings();
            foreach (RoomBooking listRoomBooking in RoomBookings)
            {
                if(listRoomBooking.ID != roomBooking.ID)
                {
                    // If booking time slot overlaps with previous bookings
                    if (listRoomBooking.StartDateTime < roomBooking.EndDateTime && listRoomBooking.EndDateTime > roomBooking.StartDateTime)
                    {
                        return false;
                    }
                    continue;
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
            return true;
        }
        #endregion

        #region Sort By Ascending
        /// <summary>
        /// This method uses Linq to sort a list of RoomBookings by StartDateTime in ascending order.
        /// </summary>
        /// <param name="listRoomBookings"></param>
        /// <returns></returns>
        public IEnumerable<RoomBooking> SortByAscending(List<RoomBooking> listRoomBookings)
        {
            return from roomBooking in listRoomBookings
                   orderby roomBooking.StartDateTime
                   select roomBooking;
        }
        #endregion

        #region Sort By Descending
        /// <summary>
        /// This method uses Linq to sort a list of RoomBookings by StartDateTime in descending order.
        /// </summary>
        /// <param name="listRoomBookings"></param>
        /// <returns></returns>
        public IEnumerable<RoomBooking> SortByDescending(List<RoomBooking> listRoomBookings)
        {
            return from roomBooking in listRoomBookings
                   orderby roomBooking.StartDateTime descending
                   select roomBooking;
        }
        #endregion

    }
}
