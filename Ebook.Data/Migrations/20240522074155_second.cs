using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebook.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EFCBookAuthor_EFCAuthor_AuthorId",
                table: "EFCBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_EFCBookAuthor_EFCBooks_BookId",
                table: "EFCBookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EFCBookAuthor",
                table: "EFCBookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_EFCBookAuthor_AuthorId",
                table: "EFCBookAuthor");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "EFCBookAuthor",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "EFCBookAuthor",
                newName: "BookID");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorID",
                table: "EFCBookAuthor",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookID",
                table: "EFCBookAuthor",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EFCBookAuthor",
                table: "EFCBookAuthor",
                columns: new[] { "AuthorID", "BookID" });

            migrationBuilder.CreateIndex(
                name: "IX_EFCBookAuthor_BookID",
                table: "EFCBookAuthor",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_EFCBookAuthor_EFCAuthor_AuthorID",
                table: "EFCBookAuthor",
                column: "AuthorID",
                principalTable: "EFCAuthor",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EFCBookAuthor_EFCBooks_BookID",
                table: "EFCBookAuthor",
                column: "BookID",
                principalTable: "EFCBooks",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EFCBookAuthor_EFCAuthor_AuthorID",
                table: "EFCBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_EFCBookAuthor_EFCBooks_BookID",
                table: "EFCBookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EFCBookAuthor",
                table: "EFCBookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_EFCBookAuthor_BookID",
                table: "EFCBookAuthor");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "EFCBookAuthor",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "EFCBookAuthor",
                newName: "AuthorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "EFCBookAuthor",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "EFCBookAuthor",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EFCBookAuthor",
                table: "EFCBookAuthor",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.CreateIndex(
                name: "IX_EFCBookAuthor_AuthorId",
                table: "EFCBookAuthor",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EFCBookAuthor_EFCAuthor_AuthorId",
                table: "EFCBookAuthor",
                column: "AuthorId",
                principalTable: "EFCAuthor",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EFCBookAuthor_EFCBooks_BookId",
                table: "EFCBookAuthor",
                column: "BookId",
                principalTable: "EFCBooks",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
