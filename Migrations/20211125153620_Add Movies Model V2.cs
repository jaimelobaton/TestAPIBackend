using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPIBackend.Migrations
{
    public partial class AddMoviesModelV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_likedMoviesUserss_Movies_MovieId",
                table: "likedMoviesUserss");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genrers_GenrerId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Studios_StudioId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_likedMoviesUserss",
                table: "likedMoviesUserss");

            migrationBuilder.DropColumn(
                name: "IdDirector",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IdGenrer",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IdStudio",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "likedMoviesUserss");

            migrationBuilder.RenameTable(
                name: "likedMoviesUserss",
                newName: "LikedMoviesUserss");

            migrationBuilder.RenameIndex(
                name: "IX_likedMoviesUserss_MovieId",
                table: "LikedMoviesUserss",
                newName: "IX_LikedMoviesUserss_MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "StudioId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenrerId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DirectorId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedMoviesUserss",
                table: "LikedMoviesUserss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedMoviesUserss_Movies_MovieId",
                table: "LikedMoviesUserss",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genrers_GenrerId",
                table: "Movies",
                column: "GenrerId",
                principalTable: "Genrers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Studios_StudioId",
                table: "Movies",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedMoviesUserss_Movies_MovieId",
                table: "LikedMoviesUserss");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genrers_GenrerId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Studios_StudioId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedMoviesUserss",
                table: "LikedMoviesUserss");

            migrationBuilder.RenameTable(
                name: "LikedMoviesUserss",
                newName: "likedMoviesUserss");

            migrationBuilder.RenameIndex(
                name: "IX_LikedMoviesUserss_MovieId",
                table: "likedMoviesUserss",
                newName: "IX_likedMoviesUserss_MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "StudioId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenrerId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdDirector",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdGenrer",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdStudio",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "likedMoviesUserss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_likedMoviesUserss",
                table: "likedMoviesUserss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_likedMoviesUserss_Movies_MovieId",
                table: "likedMoviesUserss",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genrers_GenrerId",
                table: "Movies",
                column: "GenrerId",
                principalTable: "Genrers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Studios_StudioId",
                table: "Movies",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
