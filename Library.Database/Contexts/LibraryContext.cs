using Library.Database.Extensions;
using Library.Database.Fluent;
using Library.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Database.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuthorFluentConfig());
            modelBuilder.ApplyConfiguration(new BookFluentConfig());
            modelBuilder.ApplyConfiguration(new BookAuthorFluentConfig());
            modelBuilder.ApplyConfiguration(new RoleFluentConfig());
            modelBuilder.ApplyConfiguration(new UserFluentConfig());
            modelBuilder.ApplyConfiguration(new UserRoleFluentConfig());

            modelBuilder.Seed(); 
        }
    }
}
