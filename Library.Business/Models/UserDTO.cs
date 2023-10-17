namespace Library.Business.Models
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Role { get; set; } = "Default";
    }
}
