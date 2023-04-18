using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeDaglig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Daglig_Date",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_Date",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Daglig",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Daglig_ReservationId",
                table: "Daglig",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Daglig_Reservation_ReservationId",
                table: "Daglig",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daglig_Reservation_ReservationId",
                table: "Daglig");

            migrationBuilder.DropIndex(
                name: "IX_Daglig_ReservationId",
                table: "Daglig");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Daglig");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Date",
                table: "Reservation",
                column: "Date",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Daglig_Date",
                table: "Reservation",
                column: "Date",
                principalTable: "Daglig",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
