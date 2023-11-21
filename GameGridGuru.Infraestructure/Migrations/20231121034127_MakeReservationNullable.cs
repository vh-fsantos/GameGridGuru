using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGridGuru.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeReservationNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Reservations_ReservationId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Cards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Reservations_ReservationId",
                table: "Cards",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Reservations_ReservationId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Reservations_ReservationId",
                table: "Cards",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
