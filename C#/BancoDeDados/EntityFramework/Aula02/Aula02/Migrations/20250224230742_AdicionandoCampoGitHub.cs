using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula02.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoGitHub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "User");
        }
    }
}
