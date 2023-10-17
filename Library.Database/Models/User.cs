namespace Library.Database.Models
{
    public class User
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        #region Foreign Keys

        public virtual ICollection<UserRole> UserRole { get; set; } = new List<UserRole>();

        #endregion Foreign Keys
    }
}
