using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrivateCollection.Migrations
{
    /// <inheritdoc />
    public partial class Fixtypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameGenres_BoardsGames_BoardGameId",
                table: "BoardGameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameStats_BoardsGames_BoardGameId",
                table: "BoardGameStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardsGames",
                table: "BoardsGames");

            migrationBuilder.RenameTable(
                name: "BoardsGames",
                newName: "BoardGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardGames",
                table: "BoardGames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameGenres_BoardGames_BoardGameId",
                table: "BoardGameGenres",
                column: "BoardGameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameStats_BoardGames_BoardGameId",
                table: "BoardGameStats",
                column: "BoardGameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameGenres_BoardGames_BoardGameId",
                table: "BoardGameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameStats_BoardGames_BoardGameId",
                table: "BoardGameStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardGames",
                table: "BoardGames");

            migrationBuilder.RenameTable(
                name: "BoardGames",
                newName: "BoardsGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardsGames",
                table: "BoardsGames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameGenres_BoardsGames_BoardGameId",
                table: "BoardGameGenres",
                column: "BoardGameId",
                principalTable: "BoardsGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameStats_BoardsGames_BoardGameId",
                table: "BoardGameStats",
                column: "BoardGameId",
                principalTable: "BoardsGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
