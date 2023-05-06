using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.JSON;

namespace CTTSite.Services.Interface
{
    // Made by Christian
    public interface IUserService
    {

        bool AddUser(User user);

        Task AddUserToDB(User user);

        User GetUser(int ID);

        List<User> GetUsersFromDB();

        List<User> GetAllUsers();

        User GetUserByID(int ID);

        User GetUserByEmail(string email);

        List<User> GetStaff();

        List<User> GetClients();

        List<User> GetAdmins();

        //List<User> SortStaff();

        //List<User> SortAdmins();

        //List<User> SortClients();

        List<User> SearchUserByEmail(string searchEmail);

        User DeleteUserByID(int ID);

        Task UpdateUserAsync(User userN);

        IEnumerable<User> SortById();

        IEnumerable<User> SortByIdDescending();

        IEnumerable<User> SortByEmail();

        IEnumerable<User> SortByEmailDescending();

        void SaveUsers();

        void ForgottenPassword(string email);






	}
}
