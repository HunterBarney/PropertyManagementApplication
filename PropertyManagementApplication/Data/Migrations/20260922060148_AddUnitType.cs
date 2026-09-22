using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitType_UnitTypeId",
                table: "Units",
                column: "UnitTypeId",
                principalTable: "UnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitType_UnitTypeId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "Units");
        }
    }
}
