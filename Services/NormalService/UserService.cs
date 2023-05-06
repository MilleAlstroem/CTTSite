using CTTSite.Models;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;
using CTTSite.MockData;
using Microsoft.AspNetCore.Http;
using CTTSite.Services.DB;

namespace CTTSite.Services.NormalService
{
    // Made by Christian
    public class UserService : IUserService
    {
        private List<User> _users { get; set; }
        private List<User> _admins { get; set; }
        private List<User> _staff { get; set; }
        private List<User> _clients { get; set; }
        private JsonFileService<User> JsonFileService { get; set; }
        private User User { get; set; }

        private DBServiceGeneric<User> DBServiceGeneric { get; set; }

        public UserService(JsonFileService<User> jsonUserService, DBServiceGeneric<User> dBServiceGeneric)
        {
            JsonFileService = jsonUserService;
            //_users = MockDataUser.GetMockUsers();
            //_users = JsonFileService.GetJsonObjects().ToList();

            DBServiceGeneric = dBServiceGeneric;
            _users = GetUsersFromDB();
            DBServiceGeneric.SaveObjectsAsync(_users);
        }

        #region Add User
        public bool AddUser(User user)
        {
            User existingUser =_users.Find(_user => _user.Email.ToLower() == user.Email.ToLower());

            if (existingUser == null)
            {
                _users.Add(user);
				//JsonFileService.SaveJsonObjects(_users);
				//SaveUsers();
                DBServiceGeneric.AddObjectAsync(user);

				return true;
            }
            else
            {
                return false;
            }
        }
		#endregion

		#region Save Users
        public void SaveUsers()
        {
			DBServiceGeneric.SaveObjectsAsync(_users);
		}
		#endregion

		#region Add User to DB
		public async Task AddUserToDB(User user)
        {
          await DBServiceGeneric.AddObjectAsync(User);
        }
        #endregion

        #region Get User
        public User GetUser(int ID)
        {
            User user = _users.Find(_user => _user.Id == ID);
            return user;
        }
        #endregion

        #region Get User
        public User GetUserByEmail(string email)
        {
            User user = _users.Find(_user => _user.Email == email);
            return user;
        }
        #endregion

        #region Get Users From DB
        public List<User> GetUsersFromDB()
        {
            
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();

        }
        #endregion

        #region Get Users 
        public  List<User> GetAllUsers()
        {          
           return _users;
        }
        #endregion

        #region Get User by ID
        public User GetUserByID(int ID)
        {
            foreach (User user in _users)
            {
                if (user.Id == ID)
                {
                    return user;
                }
            }
            return null;
        }
        #endregion

        #region Get Staff
        public List<User> GetStaff()
        {
			List<User> users = new List<User>();
			foreach (User u in _users)
			{
				if (u.Staff == true)
				{
					users.Add(u);
				}
			}
			
			_staff = users;
            return _staff;
        }
        #endregion

        #region Get Clients
        public List<User> GetClients()
        {
			List<User> users = new List<User>();
			foreach (User u in _users)
			{
				if ((u.Staff == false) && (u.Admin == false))
				{
					users.Add(u);
				}
			}
			
			_clients = users;
            return _clients;
        }
        #endregion

        #region Get Admins
        public List<User> GetAdmins()
        {
			List<User> users = new List<User>();
			foreach (User u in _users)
			{
				if (u.Admin == true)
				{
					users.Add(u);
				}
			}
            _admins = users;
            return _admins;
        }
        #endregion

        //#region Sort Staff
        //public List<User> SortStaff()
        //{
        //    List<User> users = new List<User>();
        //    foreach (User u in _users)
        //    {
        //        if (u.Staff == true)
        //        {
        //            users.Add(u);
        //        }
        //    }
        //    return users;
        //}
        //#endregion

        //#region Sort Admins
        //public List<User> SortAdmins()
        //{
        //    List<User> users = new List<User>();
        //    foreach (User u in _users)
        //    {
        //        if (u.Admin == true)
        //        {
        //            users.Add(u);
        //        }
        //    }
        //    return users;
        //}
        //#endregion

        //#region Sort Clients
        //public List<User> SortClients()
        //{
        //    List<User> users = new List<User>();
        //    foreach (User u in _users)
        //    {
        //        if ((u.Staff == false) && (u.Admin == false))
        //        {
        //            users.Add(u);
        //        }
        //    }
        //    return users;
        //}
        //#endregion

        #region Search User by Email
        public List<User> SearchUserByEmail(string searchEmail)
        {
            var results = _users.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower()));
            return results.ToList();   
        }
        #endregion      

        #region Delete User by ID
        public User DeleteUserByID(int ID)
        {
            User userToBeDeleted = null;
            if (GetUserByID(ID) != null)
            {                
                userToBeDeleted = GetUserByID(ID);
				_users.Remove(userToBeDeleted);
                //DBServiceGeneric.SaveObjectsAsync(_users);
                DBServiceGeneric.DeleteObjectAsync(userToBeDeleted);
            }
            return userToBeDeleted;
        }
        #endregion

        #region Update User
        public async Task UpdateUserAsync(User userN)
        {
            if (userN != null)
            {
                foreach (User userO in _users)
                {
                    if (userO.Id == userN.Id)
                    {
                        userO.Email = userN.Email;
                        userO.Password = userN.Password;
                        
                        await DBServiceGeneric.UpdateObjectAsync(userO);
                    }
                }
            }
        }
        #endregion

        #region Sort Users by ID
        public IEnumerable<User> SortById()
        {
            return from user in _users
                   orderby user.Id
                   select user;
        }
        #endregion

        #region Sort Users by ID Descending
        public IEnumerable<User> SortByIdDescending()
        {
            return from user in _users
                   orderby user.Id descending
                   select user;
        }
        #endregion

        #region Sort Users by Email
        public IEnumerable<User> SortByEmail()
        {
            return from user in _users
                   orderby user.Email
                   select user;
        }
        #endregion

        #region Sort Users by Email Descending
        public IEnumerable<User> SortByEmailDescending()
        {
            return from user in _users
                   orderby user.Email descending
                   select user;
        }
		#endregion


       
	}
}
