namespace Library.Business.Models
{
    public class BookWriteDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? CoverImageFileName { get; set; }

        public string? CoverImageContent { get; set; }

        public List<Guid>? Authors { get; set; }
    }
}
