using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Topline.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "260fed70-16bf-4897-856e-ad8444a2c449", "Heavy Metal" },
                    { "433267cb-13f5-439a-abb9-819bbf741017", "Pop Rock" },
                    { "67bd618e-9eec-4760-9300-481ce1bdcd1f", "Disco" },
                    { "8a20359f-aa32-4886-b2c5-60924d777a1c", "Classic Rock" },
                    { "c578a36c-176c-471e-9cdd-aaf79fcfdc2e", "Pop" },
                    { "f6888f01-e3e4-4bcf-9e09-1a3df63056ae", "Progressive Rock" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "260fed70-16bf-4897-856e-ad8444a2c449");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "433267cb-13f5-439a-abb9-819bbf741017");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "67bd618e-9eec-4760-9300-481ce1bdcd1f");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "8a20359f-aa32-4886-b2c5-60924d777a1c");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "c578a36c-176c-471e-9cdd-aaf79fcfdc2e");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "f6888f01-e3e4-4bcf-9e09-1a3df63056ae");
        }
    }
}
