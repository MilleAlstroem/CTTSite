namespace CTTSite.Models
{
    // Made by Christian
    public class User
    {
        private int nextId = 0;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User(string email, string password)
        {
            Id = nextId++;            
            Email = email;
            Password = password;
        }
    }
}
