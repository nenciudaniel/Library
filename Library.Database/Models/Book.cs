namespace Library.Database.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? FilePath { get; set; }

        public int? Rate { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }



        #region Foreign keys
        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }

        #endregion Foreign keys
    }
}
