using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenCareApi.Migrations
{
    /// <inheritdoc />
    public partial class FlowerOneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFlowers_Users_CreatorId",
                table: "UserFlowers");

            migrationBuilder.DropTable(
                name: "OfficialFlowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFlowers",
                table: "UserFlowers");

            migrationBuilder.RenameTable(
                name: "UserFlowers",
                newName: "Flowers");

            migrationBuilder.RenameIndex(
                name: "IX_UserFlowers_CreatorId",
                table: "Flowers",
                newName: "IX_Flowers_CreatorId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrivate",
                table: "Flowers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByAdminId",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FertilizingSchedule",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlowerKind",
                table: "Flowers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WateringSchedule",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flowers",
                table: "Flowers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Users_CreatorId",
                table: "Flowers",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Users_CreatorId",
                table: "Flowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flowers",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "CreatedByAdminId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "FertilizingSchedule",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "FlowerKind",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "WateringSchedule",
                table: "Flowers");

            migrationBuilder.RenameTable(
                name: "Flowers",
                newName: "UserFlowers");

            migrationBuilder.RenameIndex(
                name: "IX_Flowers_CreatorId",
                table: "UserFlowers",
                newName: "IX_UserFlowers_CreatorId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrivate",
                table: "UserFlowers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFlowers",
                table: "UserFlowers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OfficialFlowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloomSeason = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByAdminId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FertilizingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WateringSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialFlowers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlowers_Users_CreatorId",
                table: "UserFlowers",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
