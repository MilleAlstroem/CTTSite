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
        private IEmailService EmailService { get; set; }
        private DBServiceGeneric<User> DBServiceGeneric { get; set; }

        private string _newPassword { get; set; }

        

        public UserService(DBServiceGeneric<User> dBServiceGeneric, IEmailService emailService)
        {
            
            //_users = MockDataUser.GetMockUsers();
            //_users = JsonFileService.GetJsonObjects().ToList();

            DBServiceGeneric = dBServiceGeneric;
            _users = GetUsersFromDB();
            DBServiceGeneric.SaveObjectsAsync(_users);
            EmailService = emailService;

        }

        

        #region Add User
        /// <summary>
        /// Adds a new user to the list of users as well as to the database. Checks before adding if the user already exists.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if user does not already exist. False if user already exists</returns>
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
        /// <summary>
        /// Saves the list of users stored in UserService to the database.
        /// </summary>
        public void SaveUsers()
        {
			DBServiceGeneric.SaveObjectsAsync(_users);
		}
		#endregion		

        #region Get User
        public User GetUser(int ID)
        {
            User user = _users.Find(_user => _user.Id == ID);
            return user;
        }
        #endregion

        public int GetUserIdByEmail(string email)
        {
            User user = _users.Find(_user => _user.Email == email);
            return user.Id;
        }

        #region Get User by email
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

        #region Forgotten Password 
        public void ForgottenPassword(string email)
        {
			User user = GetUserByEmail(email);
			if (user != null)
            {
				EmailService.SendEmail(new Email("Your Password is: " + _newPassword + "\nPlease log in with this new password and go to Edit User Details to choose a new password.", "Password Recovery", user.Email));
                DeleteSavedNewPassword();
			}
		}
        #endregion

        #region Save New Password 
        public string SaveNewPassword(string password)
        { 
            _newPassword = password;
            return _newPassword;
        }
        #endregion

        #region Delete Saved Password
        private void DeleteSavedNewPassword()
        {
            _newPassword = null;            
        }
        #endregion
    }
}
