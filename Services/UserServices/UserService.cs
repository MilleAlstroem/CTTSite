using CTTSite.Models;

namespace CTTSite.Services.UserServices
{
    public class UserService : IUserService
    {
        private List<User> _users { get; set; }
        private JsonUserService JsonUserService { get; set; }

        public UserService(JsonUserService jsonUserService)
        {
            JsonUserService = jsonUserService;
            //_users = MockUsers.GetMockUsers();
            //_users = JsonUserService.GetJsonUsers().ToList();
        }
    }
}
