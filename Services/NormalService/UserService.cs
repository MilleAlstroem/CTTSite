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
            _users = MockDataUser.GetMockUsers();
            //_users = JsonUserService.GetJsonUsers().ToList();
            
        }


        public List<User> GetUsers()
        {          
            JsonFileService.SaveJsonObjects(_users);
            return _users;
        }


        public List<User> GetStaff()
        {
            foreach(User u in _users)
            {
                if(u.Staff == true)
                {
                    _staff.Add(u);
                }
            }
            return _staff;
        }


        public List<User> GetAdmins()
        {
            foreach (User u in _users)
            {
                if (u.Admin == true)
                {
                    _admins.Add(u);
                }
            }
            return _admins;
        }


        public List<User> GetClients()
        {
            foreach (User u in _users)
            {
                if ((u.Admin == false) && (u.Staff == false))
                {
                    _clients.Add(u);
                }
            }
            return _clients;
        }


        public void AddUser(User user)
        {
            _users.Add(user);
            JsonFileService.SaveJsonObjects(_users);
        }
        

        public List<User> SearchUserByEmail(string searchEmail)
        {
            var results = _users.Where(u => u.Email.Contains(searchEmail));
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

    }
}
