using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Library.Database.Models;

namespace Library.Database.Fluent
{
    public class BookAuthorFluentConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BOOKS_AUTHORS");

            builder.HasKey(x => new { x.BookId, x.AuthorId });
        }
    }
}
