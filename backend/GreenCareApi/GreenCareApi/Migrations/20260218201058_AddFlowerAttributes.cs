using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenCareApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowerAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttributesJson",
                table: "Flowers");

            migrationBuilder.CreateTable(
                name: "FlowerAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerId = table.Column<int>(type: "int", nullable: false),
                    OfficialFlowerId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowerAttributes_Flowers_OfficialFlowerId",
                        column: x => x.OfficialFlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerAttributes_OfficialFlowerId",
                table: "FlowerAttributes",
                column: "OfficialFlowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowerAttributes");

            migrationBuilder.AddColumn<string>(
                name: "AttributesJson",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
