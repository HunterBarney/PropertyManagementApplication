using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitSquareFootage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SquareFootage",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SquareFootage",
                table: "Units");
        }
    }
}
