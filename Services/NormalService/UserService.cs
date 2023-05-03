using CTTSite.Models;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;
using CTTSite.MockData;
using Microsoft.AspNetCore.Http;

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

        public UserService(JsonFileService<User> jsonUserService)
        {
            JsonFileService = jsonUserService;
            //_users = MockDataUser.GetMockUsers();
            _users = JsonFileService.GetJsonObjects().ToList();
            

		}


        public List<User> GetStaff()
        {
            _staff = SortStaff();
            return _staff;
        }

		public List<User> GetClients()
		{
			_clients = SortClients();
			return _clients;
		}

		public List<User> GetAdmins()
		{
			_admins = SortAdmins();
			return _admins;
		}

		public List<User> GetUsers()
        {
            JsonFileService.SaveJsonObjects(_users);
            return _users;
        }


        public List<User> SortStaff()
        {
            List<User> users = new List<User>();
            foreach(User u in _users)
            {
                if(u.Staff == true)
                {
                    users.Add(u);
                }
            }
            return users;
        }


        public List<User> SortAdmins()
        {
			List<User> users = new List<User>();
			foreach (User u in _users)
			{
				if (u.Admin == true)
				{
					users.Add(u);
				}
			}
			return users;
		}


        public List<User> SortClients()
        {
			List<User> users = new List<User>();
			foreach (User u in _users)
			{
				if ((u.Staff == false) && (u.Admin == false))
				{
					users.Add(u);
				}
			}
			return users;
		}


        public bool AddUser(User user)
        {
            User existingUser =_users.Find(_user => _user.Email.ToLower() == user.Email.ToLower());

            if (existingUser == null)
            {
                _users.Add(user);
                JsonFileService.SaveJsonObjects(_users);
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public List<User> SearchUserByEmail(string searchEmail)
        {
            var results = _users.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower()));
            return results.ToList();   
        }


        public User GetUser(int ID)
        {
            User user = _users.Find(_user => _user.Id == ID);
            return user;
        }


        public User DeleteUser(int ID)
        {
            
            User userToBeDeleted = _users.Find(_user => _user.Id == ID);
            if (userToBeDeleted != null)
            {
                _users.Remove(userToBeDeleted);

                JsonFileService.SaveJsonObjects(_users);
            }
            return userToBeDeleted;
        }

        public IEnumerable<User> SortById()
        {
            return from user in _users
                   orderby user.Id
                   select user;
        }

        public IEnumerable<User> SortByIdDescending()
        {
            return from user in _users
                   orderby user.Id descending
                   select user;
        }

        public IEnumerable<User> SortByEmail()
        {
            return from user in _users
                   orderby user.Email
                   select user;
        }

        public IEnumerable<User> SortByEmailDescending()
        {
            return from user in _users
                   orderby user.Email descending
                   select user;
        }

    }
}
