using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Topline.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTaggedItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaggedItems",
                columns: new[] { "Id", "ItemId", "TagId" },
                values: new object[,]
                {
                    { "02a1e577-de0a-44d6-b8b5-8cf3eaa69b06", "1bbc3f6e-3779-4ec3-9fbe-3e314b2f94bd", "260fed70-16bf-4897-856e-ad8444a2c449" },
                    { "061881bd-3066-406d-ad2f-51f0109baf6c", "a0ec7334-e7ac-40d6-8c82-40de9865cbc9", "f6888f01-e3e4-4bcf-9e09-1a3df63056ae" },
                    { "90cb1080-d81b-4157-95c0-2f84f0d18aa0", "a0ec7334-e7ac-40d6-8c82-40de9865cbc9", "8a20359f-aa32-4886-b2c5-60924d777a1c" },
                    { "b1a12ac6-58bf-4917-a01c-f2e9fa747a10", "77a8e9ee-28f2-4823-8794-3a7bc33344f0", "f6888f01-e3e4-4bcf-9e09-1a3df63056ae" },
                    { "e7a3a892-f097-4c40-b65f-7d9a12b4bb5f", "4241c4cb-77c8-4a65-bae7-61b489215b73", "f6888f01-e3e4-4bcf-9e09-1a3df63056ae" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaggedItems",
                keyColumn: "Id",
                keyValue: "02a1e577-de0a-44d6-b8b5-8cf3eaa69b06");

            migrationBuilder.DeleteData(
                table: "TaggedItems",
                keyColumn: "Id",
                keyValue: "061881bd-3066-406d-ad2f-51f0109baf6c");

            migrationBuilder.DeleteData(
                table: "TaggedItems",
                keyColumn: "Id",
                keyValue: "90cb1080-d81b-4157-95c0-2f84f0d18aa0");

            migrationBuilder.DeleteData(
                table: "TaggedItems",
                keyColumn: "Id",
                keyValue: "b1a12ac6-58bf-4917-a01c-f2e9fa747a10");

            migrationBuilder.DeleteData(
                table: "TaggedItems",
                keyColumn: "Id",
                keyValue: "e7a3a892-f097-4c40-b65f-7d9a12b4bb5f");
        }
    }
}
