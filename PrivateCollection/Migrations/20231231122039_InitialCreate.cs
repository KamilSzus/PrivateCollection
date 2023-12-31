using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrivateCollection.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardsGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    NumberOfGamesPlayed = table.Column<int>(type: "integer", nullable: false),
                    PublishingHouse = table.Column<string>(type: "text", nullable: false),
                    InGameTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    LastGame = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GameCount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardsGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Authors = table.Column<List<string>>(type: "text[]", nullable: false),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false),
                    ReadTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Genre = table.Column<int>(type: "integer", nullable: false),
                    BoardGameId = table.Column<int>(type: "integer", nullable: true),
                    BookId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_BoardsGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardsGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BoardGameId",
                table: "Categories",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BookId",
                table: "Categories",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "BoardsGames");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
