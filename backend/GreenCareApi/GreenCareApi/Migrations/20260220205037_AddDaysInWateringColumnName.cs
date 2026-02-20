using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenCareApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDaysInWateringColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WateringInterval",
                table: "Flowers",
                newName: "WateringIntervalDays");

            migrationBuilder.RenameColumn(
                name: "FertilizingInterval",
                table: "Flowers",
                newName: "FertilizingIntervalDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WateringIntervalDays",
                table: "Flowers",
                newName: "WateringInterval");

            migrationBuilder.RenameColumn(
                name: "FertilizingIntervalDays",
                table: "Flowers",
                newName: "FertilizingInterval");
        }
    }
}
