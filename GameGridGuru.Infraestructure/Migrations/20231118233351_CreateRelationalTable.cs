using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGridGuru.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cards_CardId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CardProduct",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardProduct", x => new { x.CardId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CardProduct_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardProduct_ProductId",
                table: "CardProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardProduct");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CardId",
                table: "Products",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cards_CardId",
                table: "Products",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }
    }
}
