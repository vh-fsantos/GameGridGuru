using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGridGuru.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdCardProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CardProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CardProduct");
        }
    }
}
