using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeccondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30bca869-beaf-45b1-844b-b84aa5aedbde", null, "client", "client" },
                    { "7187bfae-d8b7-458c-874b-85b0fa6ec79d", null, "admin", "admin" },
                    { "9734e2d9-f90b-445f-a9f6-20bbd15df99f", null, "seller", "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30bca869-beaf-45b1-844b-b84aa5aedbde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7187bfae-d8b7-458c-874b-85b0fa6ec79d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9734e2d9-f90b-445f-a9f6-20bbd15df99f");
        }
    }
}
