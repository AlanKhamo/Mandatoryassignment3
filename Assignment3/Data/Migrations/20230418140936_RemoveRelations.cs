using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd");

            migrationBuilder.DropTable(
                name: "Daglig");

            migrationBuilder.DropIndex(
                name: "IX_CheckInd_DagligDate",
                table: "CheckInd");

            migrationBuilder.DropColumn(
                name: "DagligDate",
                table: "CheckInd");

            migrationBuilder.CreateTable(
                name: "Kitchen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpectedAdults = table.Column<int>(type: "int", nullable: false),
                    ExpectedChildren = table.Column<int>(type: "int", nullable: false),
                    CheckedInAdultes = table.Column<int>(type: "int", nullable: false),
                    CheckecInChilds = table.Column<int>(type: "int", nullable: false),
                    MissingAdults = table.Column<int>(type: "int", nullable: false),
                    MissingChildren = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitchen", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitchen");

            migrationBuilder.AddColumn<DateTime>(
                name: "DagligDate",
                table: "CheckInd",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Daglig",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daglig", x => x.Date);
                    table.ForeignKey(
                        name: "FK_Daglig_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckInd_DagligDate",
                table: "CheckInd",
                column: "DagligDate");

            migrationBuilder.CreateIndex(
                name: "IX_Daglig_ReservationId",
                table: "Daglig",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd",
                column: "DagligDate",
                principalTable: "Daglig",
                principalColumn: "Date");
        }
    }
}
