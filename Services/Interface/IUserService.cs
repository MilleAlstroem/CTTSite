using CTTSite.Models;
using CTTSite.Services.JSON;

namespace CTTSite.Services.Interface
{
    // Made by Christian
    public interface IUserService
    {
        List<User> GetUsers();

        public List<User> GetClients();

        public List<User> GetAdmins();

        public List<User> GetStaff();

        bool AddUser(User user);

        List<User> SearchUserByEmail(string searchEmail);

        User GetUser(int ID);

        User DeleteUser(int ID);
        
    }
}
