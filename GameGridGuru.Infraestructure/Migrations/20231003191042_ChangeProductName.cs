using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGridGuru.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Description");
        }
    }
}
