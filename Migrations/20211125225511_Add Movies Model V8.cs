using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPIBackend.Migrations
{
    public partial class AddMoviesModelV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "LikedMoviesUserss",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "LikedMoviesUserss");
        }
    }
}
