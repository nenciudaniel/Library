using Library.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Database.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            AddRoles(modelBuilder);

            AddUsers(modelBuilder);

            AddUsersRoles(modelBuilder);

            AddAuthors(modelBuilder);

            AddBooks(modelBuilder);

            AddBooksAuthors(modelBuilder);
        }

        private static void AddAuthors(ModelBuilder modelBuilder)
        {
            List<Author> data = new()
            {
                new()
                {
                    FirstName = "J.K.",
                    LastName = "Rowling",
                    CreatedBy = "danielnenciu",
                    CreatedOn  = DateTime.UtcNow,
                    Id = new Guid("7FA313EC-DCBD-440D-AD68-AFFD22EF5E52")
                },
                new()
                {
                    FirstName = "William Gilmore",
                    LastName = "Simms",
                    CreatedBy = "danielnenciu",
                    CreatedOn  = DateTime.UtcNow,
                    Id = new Guid("96A6BD06-C813-4921-B512-1798CCE990EF")
                },
                new()
                {
                    FirstName = "Donald",
                    LastName = "Gray",
                    CreatedBy = "danielnenciu",
                    CreatedOn  = DateTime.UtcNow,
                    Id = new Guid("145FFC48-EDC5-4588-8895-26891C887C92")
                },
                new()
                {
                    FirstName = "Jane",
                    LastName = "Austen",
                    CreatedBy = "danielnenciu",
                    CreatedOn  = DateTime.UtcNow,
                    Id = new Guid("D3C3200C-29D8-4057-9BF0-919DFFDF7FD9")
                },
            };

            modelBuilder.Entity<Author>().HasData(data);
        }

        private static void AddBooks(ModelBuilder modelBuilder)
        {
            List<Book> data = new()
            {
                new()
                {
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Description = "Harry Potter has never played a sport while flying on a broomstick. He's never worn a cloak of invisibility, befriended a giant, or helped hatch a dragon. All Harry knows is a miserable life with the Dursleys, his horrible aunt and uncle, and their abominable son, Dudley. Harry's room is a tiny closet at the foot of the stairs, and he hasn't had a birthday party in eleven years.\r\n\r\nBut all that is about change when a mysterious letter arrives by owl messenger: a letter with an invitation to a wonderful place he never dreamed existed. There he finds not only friends, aerial sports, and magic around every corner, but a great destiny that's been waiting for him...if Harry can survive the encounter.",
                    CreatedBy = "danielnenciu",
                    CreatedOn  = DateTime.UtcNow,
                    Id = new Guid("09FE7A60-CBDC-4891-935E-66807AB7A321"),
                    FilePath = "HarryPotter.png"
                },
                new()
                {
                    Title = "Mellichampe",
                    Description = "Sequel to The partisan.",
                    CreatedBy = "danielnenciu",
                    CreatedOn  = DateTime.UtcNow,
                    Id = new Guid("EAD2230E-5136-4E20-A0E6-34DC42975A72"),
                    FilePath = "Mellichampe.png"
                },
                new()
                {
                    Title = "Pride and Prejudice",
                    Description = "A perennial favorite in the Norton Critical Editions series, Pride and Prejudice is based on the 1813 first edition text, which has been thoroughly annotated for undergraduate readers.",
                    CreatedBy = "danielnenciu",
                    CreatedOn  = DateTime.UtcNow,
                    Id = new Guid("9924B888-1257-4FA9-917A-F6F5FE1DFC16"),
                    FilePath = "Pride.png"
                },
            };

            modelBuilder.Entity<Book>().HasData(data);
        }

        private static void AddBooksAuthors(ModelBuilder modelBuilder)
        {
            List<BookAuthor> data = new()
            {
                //Harry Potter and the Sorcerer's Stone
                new()
                {
                    AuthorId = new Guid("7FA313EC-DCBD-440D-AD68-AFFD22EF5E52"),
                    BookId = new Guid("09FE7A60-CBDC-4891-935E-66807AB7A321")
                },
                //Mellichampe
                new()
                {
                    AuthorId = new Guid("96A6BD06-C813-4921-B512-1798CCE990EF"),
                    BookId = new Guid("EAD2230E-5136-4E20-A0E6-34DC42975A72")
                },
                //pride and prejudice
                new()
                {
                    AuthorId = new Guid("145FFC48-EDC5-4588-8895-26891C887C92"),
                    BookId = new Guid("9924B888-1257-4FA9-917A-F6F5FE1DFC16")
                },
                new()
                {
                    AuthorId = new Guid("D3C3200C-29D8-4057-9BF0-919DFFDF7FD9"),
                    BookId = new Guid("9924B888-1257-4FA9-917A-F6F5FE1DFC16")
                },
            };

            modelBuilder.Entity<BookAuthor>().HasData(data);
        }

        private static void AddRoles(ModelBuilder modelBuilder)
        {
            List<Role> data = new()
            {
                new()
                {
                    Name = "Admin",
                    Id = 1
                },
            };

            modelBuilder.Entity<Role>().HasData(data);
        }

        private static void AddUsers(ModelBuilder modelBuilder)
        {
            List<User> data = new()
            {
                new()
                {
                    FirstName = "Daniel",
                    LastName = "Nenciu",
                    Username = "danielnenciu"
                },
                new()
                {
                    FirstName = "Default",
                    LastName = "User",
                    Username = "defaultUser"
                }
            };

            modelBuilder.Entity<User>().HasData(data);
        }

        private static void AddUsersRoles(ModelBuilder modelBuilder)
        {
            List<UserRole> data = new()
            {
                new()
                {
                    Username = "danielnenciu", 
                    RoleId = 1,
                    CreatedBy = "danielnenciu",
                    CreatedOn = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<UserRole>().HasData(data);
        }
    }
}
