namespace Library.Database.Models
{
    public class UserRole
    {
        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }



        #region Foreign keys
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }

        #endregion Foreign keys
    }
}
