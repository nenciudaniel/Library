using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTHORS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BOOKS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "BOOKS_AUTHORS",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKS_AUTHORS", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BOOKS_AUTHORS_AUTHORS_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AUTHORS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOKS_AUTHORS_BOOKS_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOKS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS_ROLES",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username1 = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS_ROLES", x => new { x.Username, x.RoleId });
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_USERS_Username1",
                        column: x => x.Username1,
                        principalTable: "USERS",
                        principalColumn: "Username");
                });

            migrationBuilder.InsertData(
                table: "AUTHORS",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "FirstName", "LastModified", "LastName", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("145ffc48-edc5-4588-8895-26891c887c92"), "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6922), "Donald", null, "Gray", null },
                    { new Guid("7fa313ec-dcbd-440d-ad68-affd22ef5e52"), "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6892), "J.K.", null, "Rowling", null },
                    { new Guid("96a6bd06-c813-4921-b512-1798cce990ef"), "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6918), "William Gilmore", null, "Simms", null },
                    { new Guid("d3c3200c-29d8-4057-9bf0-919dffdf7fd9"), "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6923), "Jane", null, "Austen", null }
                });

            migrationBuilder.InsertData(
                table: "BOOKS",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "FilePath", "LastModified", "ModifiedBy", "Rate", "Title" },
                values: new object[,]
                {
                    { new Guid("09fe7a60-cbdc-4891-935e-66807ab7a321"), "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6945), "Harry Potter has never played a sport while flying on a broomstick. He's never worn a cloak of invisibility, befriended a giant, or helped hatch a dragon. All Harry knows is a miserable life with the Dursleys, his horrible aunt and uncle, and their abominable son, Dudley. Harry's room is a tiny closet at the foot of the stairs, and he hasn't had a birthday party in eleven years.\r\n\r\nBut all that is about change when a mysterious letter arrives by owl messenger: a letter with an invitation to a wonderful place he never dreamed existed. There he finds not only friends, aerial sports, and magic around every corner, but a great destiny that's been waiting for him...if Harry can survive the encounter.", "HarryPotter.png", null, null, null, "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("9924b888-1257-4fa9-917a-f6f5fe1dfc16"), "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6955), "A perennial favorite in the Norton Critical Editions series, Pride and Prejudice is based on the 1813 first edition text, which has been thoroughly annotated for undergraduate readers.", "Pride.png", null, null, null, "Pride and Prejudice" },
                    { new Guid("ead2230e-5136-4e20-a0e6-34dc42975a72"), "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6952), "Sequel to The partisan.", "Mellichampe.png", null, null, null, "Mellichampe" }
                });

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "Username", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "danielnenciu", "Daniel", "Nenciu" },
                    { "defaultUser", "Default", "User" }
                });

            migrationBuilder.InsertData(
                table: "BOOKS_AUTHORS",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { new Guid("7fa313ec-dcbd-440d-ad68-affd22ef5e52"), new Guid("09fe7a60-cbdc-4891-935e-66807ab7a321") },
                    { new Guid("145ffc48-edc5-4588-8895-26891c887c92"), new Guid("9924b888-1257-4fa9-917a-f6f5fe1dfc16") },
                    { new Guid("d3c3200c-29d8-4057-9bf0-919dffdf7fd9"), new Guid("9924b888-1257-4fa9-917a-f6f5fe1dfc16") },
                    { new Guid("96a6bd06-c813-4921-b512-1798cce990ef"), new Guid("ead2230e-5136-4e20-a0e6-34dc42975a72") }
                });

            migrationBuilder.InsertData(
                table: "USERS_ROLES",
                columns: new[] { "RoleId", "Username", "CreatedBy", "CreatedOn", "Username1" },
                values: new object[] { 1, "danielnenciu", "danielnenciu", new DateTime(2023, 10, 16, 1, 25, 8, 416, DateTimeKind.Utc).AddTicks(6865), null });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKS_AUTHORS_AuthorId",
                table: "BOOKS_AUTHORS",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_RoleId",
                table: "USERS_ROLES",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_Username1",
                table: "USERS_ROLES",
                column: "Username1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOKS_AUTHORS");

            migrationBuilder.DropTable(
                name: "USERS_ROLES");

            migrationBuilder.DropTable(
                name: "AUTHORS");

            migrationBuilder.DropTable(
                name: "BOOKS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
