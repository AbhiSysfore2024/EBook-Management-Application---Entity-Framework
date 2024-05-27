using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebook.Data.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EFCCredentials",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EFCCredentials",
                table: "EFCCredentials",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EFCCredentials",
                table: "EFCCredentials");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EFCCredentials");
        }
    }
}
