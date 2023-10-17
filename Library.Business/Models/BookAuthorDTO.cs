namespace Library.Business.Models
{
    public class BookAuthorDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }


        public Guid? AuthorId { get; set; }

        public string? AuthorFirstName { get; set; }

        public string? AuthorLastName { get; set; }

        public string AuthorFullName => string.IsNullOrWhiteSpace(AuthorLastName) || string.IsNullOrWhiteSpace(AuthorFirstName) ? "N/A" : $"{AuthorLastName} {AuthorFirstName}";
    }
}
