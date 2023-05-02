using CTTSite.Models;
using CTTSite.Services.JSON;

namespace CTTSite.Services.Interface
{
    // Made by Christian
    public interface IUserService
    {
        List<User> GetUsers();

        void AddStaffUser(User user);


        void AddClientUser(User user);


        List<User> SearchUserByEmail(string searchEmail);



        User GetUser(int ID);



        User DeleteUser(int ID);
        
    }
}
