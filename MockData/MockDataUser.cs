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
            new User("chilterntalkingtherapies@gmail.com", "Admin!88", true, true),
            new User("testStaff@email.com", "Test1234", false, true),
            new User("testClient@email.com", "Test1234", false, false)
        };

        public static List<User> GetMockUsers()
        {
            return users;
        }
    }
}
