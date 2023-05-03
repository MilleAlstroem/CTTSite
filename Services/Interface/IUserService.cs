using CTTSite.Models;
using CTTSite.Services.JSON;

namespace CTTSite.Services.Interface
{
    // Made by Christian
    public interface IUserService
    {
        List<User> GetUsers();



		List<User> GetStaff();


		List<User> GetClients();


		List<User> GetAdmins();


        List<User> SortStaff();



        List<User> SortAdmins();



       List<User> SortClients();
		



		bool AddUser(User user);



        List<User> SearchUserByEmail(string searchEmail);



        User GetUser(int ID);



        User DeleteUser(int ID);


        IEnumerable<User> SortById();


        IEnumerable<User> SortByIdDescending();


        IEnumerable<User> SortByEmail();


        IEnumerable<User> SortByEmailDescending();
        

    }
}
