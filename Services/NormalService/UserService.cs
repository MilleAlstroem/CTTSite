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
        private JsonUserService JsonUserService { get; set; }

        public UserService(JsonUserService jsonUserService)
        {
            JsonUserService = jsonUserService;
            _users = MockDataUser.GetMockUsers();
            //_users = JsonUserService.GetJsonUsers().ToList();
        }

        public List<User> GetUsers()
        {          
            return _users;
        }
    }
}
