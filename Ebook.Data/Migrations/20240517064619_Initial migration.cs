using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebook.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EFCAuthor",
                columns: table => new
                {
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFCAuthor", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "EFCBooks",
                columns: table => new
                {
                    BookID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Publication_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    AvgRating = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookGenre = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFCBooks", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "EFCCredentials",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EFCBookAuthor",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFCBookAuthor", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_EFCBookAuthor_EFCAuthor_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "EFCAuthor",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EFCBookAuthor_EFCBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "EFCBooks",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EFCBookAuthor_AuthorId",
                table: "EFCBookAuthor",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EFCBookAuthor");

            migrationBuilder.DropTable(
                name: "EFCCredentials");

            migrationBuilder.DropTable(
                name: "EFCAuthor");

            migrationBuilder.DropTable(
                name: "EFCBooks");
        }
    }
}
