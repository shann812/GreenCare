using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenCareApi.Migrations
{
    /// <inheritdoc />
    public partial class FlowerInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfficialFlowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WateringSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FertilizingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByAdminId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BloomSeason = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttributesJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialFlowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFlowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastWateringDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WateringInterval = table.Column<int>(type: "int", nullable: true),
                    LastFertilizingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FertilizingInterval = table.Column<int>(type: "int", nullable: true),
                    OnModeration = table.Column<bool>(type: "bit", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BloomSeason = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttributesJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFlowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFlowers_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFlowers_CreatorId",
                table: "UserFlowers",
                column: "CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficialFlowers");

            migrationBuilder.DropTable(
                name: "UserFlowers");
        }
    }
}
