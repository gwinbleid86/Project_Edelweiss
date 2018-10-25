using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class ChangeRangeIdToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Ranges_RangeId",
                table: "Tariffs");

            migrationBuilder.AlterColumn<int>(
                name: "RangeId",
                table: "Tariffs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Ranges_RangeId",
                table: "Tariffs",
                column: "RangeId",
                principalTable: "Ranges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Ranges_RangeId",
                table: "Tariffs");

            migrationBuilder.AlterColumn<int>(
                name: "RangeId",
                table: "Tariffs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Ranges_RangeId",
                table: "Tariffs",
                column: "RangeId",
                principalTable: "Ranges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
