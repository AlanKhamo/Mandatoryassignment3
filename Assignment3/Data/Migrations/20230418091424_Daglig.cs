using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3.Data.Migrations
{
    /// <inheritdoc />
    public partial class Daglig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DagligDate",
                table: "CheckInd",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Daglig",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daglig", x => x.Date);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Date",
                table: "Reservation",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckInd_DagligDate",
                table: "CheckInd",
                column: "DagligDate");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd",
                column: "DagligDate",
                principalTable: "Daglig",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Daglig_Date",
                table: "Reservation",
                column: "Date",
                principalTable: "Daglig",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Daglig_Date",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "Daglig");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_Date",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_CheckInd_DagligDate",
                table: "CheckInd");

            migrationBuilder.DropColumn(
                name: "DagligDate",
                table: "CheckInd");
        }
    }
}
