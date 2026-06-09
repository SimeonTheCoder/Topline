using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Topline.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Artist", "Description", "Name", "Type", "Year" },
                values: new object[,]
                {
                    { "00baf8a9-c7c0-42ab-9bcb-706b108e552f", "Scorpions", "A high-energy rock anthem built for stadiums and heavy rotation.", "Rock You Like a Hurricane", 0, 1984 },
                    { "023ab7d9-4bb3-4315-95bb-47dee5da999f", "Deep Purple", "A legendary riff-driven song inspired by a real-life recording studio fire.", "Smoke on the Water", 0, 1972 },
                    { "1b4cf44a-4d5c-4071-9035-5cbd1bf523f6", "Dire Straits", "A breakout track showcasing intricate guitar work and observational lyrics about bar-band musicians.", "Sultans of Swing", 0, 1978 },
                    { "1bbc3f6e-3779-4ec3-9fbe-3e314b2f94bd", "Rainbow", "A powerful blend of hard rock and early metal showcasing virtuosic musicianship.", "Rising", 1, 1976 },
                    { "1e563b77-5fd7-445f-8733-99e2ba4931c7", "The Alan Parsons Project", "A concept album exploring gambling, fate, and chance through layered progressive arrangements.", "The Turn of a Friendly Card", 1, 1980 },
                    { "4241c4cb-77c8-4a65-bae7-61b489215b73", "Pink Floyd", "A landmark progressive rock album exploring themes of time, money, and mental health through seamless sonic storytelling.", "The Dark Side of the Moon", 1, 1973 },
                    { "77a8e9ee-28f2-4823-8794-3a7bc33344f0", "Pink Floyd", "A reflective album built around absence and tribute, especially honoring former member Syd Barrett.", "Wish You Were Here", 1, 1975 },
                    { "92aede7c-b5aa-4ffc-a512-971ea8e9cb7e", "Dire Straits", "A polished rock album blending emotional storytelling with cutting-edge 80s production.", "Brothers in Arms", 1, 1985 },
                    { "9847baf5-736e-4751-8ff3-2e8774b22972", "Deep Purple", "A defining hard rock album famously featuring one of the most iconic riffs in rock history.", "Machine Head", 1, 1972 },
                    { "a0ec7334-e7ac-40d6-8c82-40de9865cbc9", "The Alan Parsons Project", "A sleek, atmospheric album blending progressive rock with pop sensibilities.", "Eye in the Sky", 1, 1982 },
                    { "a29f338e-4de8-4311-8644-6bfd1c996880", "Pink Floyd", "A quirky debut single about a peculiar character with unusual habits that set early Pink Floyd apart.", "Arnold Layne", 0, 1967 },
                    { "f2a94813-1697-442a-913d-b153de85cd28", "Rainbow", "An epic, dramatic track built like a fantasy saga in guitar form.", "Stargazer", 0, 1976 },
                    { "fecfd254-56ac-4320-9108-a9af567fbffb", "Scorpions", "A hard rock album that helped define the band’s global arena-rock sound in the 80s.", "Love at First Sting", 1, 1984 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "00baf8a9-c7c0-42ab-9bcb-706b108e552f");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "023ab7d9-4bb3-4315-95bb-47dee5da999f");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "1b4cf44a-4d5c-4071-9035-5cbd1bf523f6");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "1bbc3f6e-3779-4ec3-9fbe-3e314b2f94bd");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "1e563b77-5fd7-445f-8733-99e2ba4931c7");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "4241c4cb-77c8-4a65-bae7-61b489215b73");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "77a8e9ee-28f2-4823-8794-3a7bc33344f0");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "92aede7c-b5aa-4ffc-a512-971ea8e9cb7e");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "9847baf5-736e-4751-8ff3-2e8774b22972");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "a0ec7334-e7ac-40d6-8c82-40de9865cbc9");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "a29f338e-4de8-4311-8644-6bfd1c996880");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "f2a94813-1697-442a-913d-b153de85cd28");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "fecfd254-56ac-4320-9108-a9af567fbffb");
        }
    }
}
