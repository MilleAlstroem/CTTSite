namespace CTTSite.Models
{
    // Made by Christian
    public class User
    {
        private int nextId = 0;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Staff { get; set; }


        public User()
        {
        }

        public User(string email, string password, bool admin, bool staff)
        {
            Id = nextId++;            
            Email = email;
            Password = password;
            Admin = admin;
            Staff = staff;
        }
    }
}
