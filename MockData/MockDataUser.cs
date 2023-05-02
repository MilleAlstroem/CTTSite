using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTTSite.Models;

namespace CTTSite.MockData
{
    // Made by Christian 
    public class MockDataUser
    {
        private static List<User> users = new List<User>()
        {
            new User("chilterntalkingtherapies@gmail.com", "Admin!88"),
            new User("testStaff@email.com", "Test1234"),
            new User("testClient@email.com", "Test1234")
        };

        public static List<User> GetMockUsers()
        {
            return users;
        }
    }
}
