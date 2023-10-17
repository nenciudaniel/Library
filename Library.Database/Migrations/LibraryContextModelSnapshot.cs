﻿// <auto-generated />
using System;
using Library.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Database.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Database.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AUTHORS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7fa313ec-dcbd-440d-ad68-affd22ef5e52"),
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6892),
                            FirstName = "J.K.",
                            LastName = "Rowling"
                        },
                        new
                        {
                            Id = new Guid("96a6bd06-c813-4921-b512-1798cce990ef"),
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6918),
                            FirstName = "William Gilmore",
                            LastName = "Simms"
                        },
                        new
                        {
                            Id = new Guid("145ffc48-edc5-4588-8895-26891c887c92"),
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6922),
                            FirstName = "Donald",
                            LastName = "Gray"
                        },
                        new
                        {
                            Id = new Guid("d3c3200c-29d8-4057-9bf0-919dffdf7fd9"),
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6923),
                            FirstName = "Jane",
                            LastName = "Austen"
                        });
                });

            modelBuilder.Entity("Library.Database.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("BOOKS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("09fe7a60-cbdc-4891-935e-66807ab7a321"),
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6945),
                            Description = "Harry Potter has never played a sport while flying on a broomstick. He's never worn a cloak of invisibility, befriended a giant, or helped hatch a dragon. All Harry knows is a miserable life with the Dursleys, his horrible aunt and uncle, and their abominable son, Dudley. Harry's room is a tiny closet at the foot of the stairs, and he hasn't had a birthday party in eleven years.\r\n\r\nBut all that is about change when a mysterious letter arrives by owl messenger: a letter with an invitation to a wonderful place he never dreamed existed. There he finds not only friends, aerial sports, and magic around every corner, but a great destiny that's been waiting for him...if Harry can survive the encounter.",
                            FilePath = "HarryPotter.png",
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            Id = new Guid("ead2230e-5136-4e20-a0e6-34dc42975a72"),
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6952),
                            Description = "Sequel to The partisan.",
                            FilePath = "Mellichampe.png",
                            Title = "Mellichampe"
                        },
                        new
                        {
                            Id = new Guid("9924b888-1257-4fa9-917a-f6f5fe1dfc16"),
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6955),
                            Description = "A perennial favorite in the Norton Critical Editions series, Pride and Prejudice is based on the 1813 first edition text, which has been thoroughly annotated for undergraduate readers.",
                            FilePath = "Pride.png",
                            Title = "Pride and Prejudice"
                        });
                });

            modelBuilder.Entity("Library.Database.Models.BookAuthor", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BOOKS_AUTHORS", (string)null);

                    b.HasData(
                        new
                        {
                            BookId = new Guid("09fe7a60-cbdc-4891-935e-66807ab7a321"),
                            AuthorId = new Guid("7fa313ec-dcbd-440d-ad68-affd22ef5e52")
                        },
                        new
                        {
                            BookId = new Guid("ead2230e-5136-4e20-a0e6-34dc42975a72"),
                            AuthorId = new Guid("96a6bd06-c813-4921-b512-1798cce990ef")
                        },
                        new
                        {
                            BookId = new Guid("9924b888-1257-4fa9-917a-f6f5fe1dfc16"),
                            AuthorId = new Guid("145ffc48-edc5-4588-8895-26891c887c92")
                        },
                        new
                        {
                            BookId = new Guid("9924b888-1257-4fa9-917a-f6f5fe1dfc16"),
                            AuthorId = new Guid("d3c3200c-29d8-4057-9bf0-919dffdf7fd9")
                        });
                });

            modelBuilder.Entity("Library.Database.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ROLES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Library.Database.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Username");

                    b.ToTable("USERS", (string)null);

                    b.HasData(
                        new
                        {
                            Username = "danielnenciu",
                            FirstName = "Daniel",
                            LastName = "Nenciu"
                        },
                        new
                        {
                            Username = "defaultUser",
                            FirstName = "Default",
                            LastName = "User"
                        });
                });

            modelBuilder.Entity("Library.Database.Models.UserRole", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username1")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Username", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username1");

                    b.ToTable("USERS_ROLES", (string)null);

                    b.HasData(
                        new
                        {
                            Username = "danielnenciu",
                            RoleId = 1,
                            CreatedBy = "danielnenciu",
                            CreatedOn = new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6865)
                        });
                });

            modelBuilder.Entity("Library.Database.Models.BookAuthor", b =>
                {
                    b.HasOne("Library.Database.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Database.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.Database.Models.UserRole", b =>
                {
                    b.HasOne("Library.Database.Models.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Database.Models.User", null)
                        .WithMany("UserRole")
                        .HasForeignKey("Username1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Library.Database.Models.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Library.Database.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Library.Database.Models.Role", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Library.Database.Models.User", b =>
                {
                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
