namespace Library.Business.Models
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }   

        public string? Description { get; set; }

        public string? FilePath { get; set; }

        public string? CoverImageFileName { get; set; }
        
        public string? CoverImageContent { get; set; }

        public List<AuthorDTO>? Authors { get; set; }
    }
}
