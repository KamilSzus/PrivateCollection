using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrivateCollection.Migrations
{
    /// <inheritdoc />
    public partial class Userrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15542669-104b-4166-918a-5e566e3cf568", null, "Admin", "ADMIN" },
                    { "dc1aa5b4-5cd2-4978-a3c6-73ab289dc004", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15542669-104b-4166-918a-5e566e3cf568");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc1aa5b4-5cd2-4978-a3c6-73ab289dc004");
        }
    }
}
