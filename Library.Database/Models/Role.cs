namespace Library.Database.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }


        #region Foreign keys
        public virtual ICollection<UserRole> UserRole { get; set; } = new List<UserRole>();

        #endregion Foreign keys
    }
}
