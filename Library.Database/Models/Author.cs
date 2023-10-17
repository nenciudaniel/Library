namespace Library.Database.Models
{
    public class Author
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }



        #region Foreign keys
        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }

        #endregion Foreign keys
    }
}
