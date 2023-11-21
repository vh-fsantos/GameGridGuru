using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGridGuru.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsClosedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Cards",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Cards");
        }
    }
}
