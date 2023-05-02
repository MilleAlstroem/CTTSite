using CTTSite.Models;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;
using CTTSite.MockData;

namespace CTTSite.Services.NormalService
{
    // Made by Christian
    public class UserService : IUserService
    {
        private List<User> _users { get; set; }
        private JsonFileService<User> JsonFileService { get; set; }

        private User DeletedUser { get; set; }

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
        public void AddStaffUser(User user)
        {
            _users.Add(user);
            JsonFileService.SaveJsonObjects(_users);
        }
        public void AddClientUser(User user)
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
