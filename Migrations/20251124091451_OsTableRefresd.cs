using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolgozat.Migrations
{
    /// <inheritdoc />
    public partial class OsTableRefresd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Os_Computers_ComputerId",
                table: "Os");

            migrationBuilder.AlterColumn<int>(
                name: "ComputerId",
                table: "Os",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Os_Computers_ComputerId",
                table: "Os",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Os_Computers_ComputerId",
                table: "Os");

            migrationBuilder.AlterColumn<int>(
                name: "ComputerId",
                table: "Os",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Os_Computers_ComputerId",
                table: "Os",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
