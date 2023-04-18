using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeDaglig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DagligDate",
                table: "CheckInd",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd",
                column: "DagligDate",
                principalTable: "Daglig",
                principalColumn: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DagligDate",
                table: "CheckInd",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInd_Daglig_DagligDate",
                table: "CheckInd",
                column: "DagligDate",
                principalTable: "Daglig",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
