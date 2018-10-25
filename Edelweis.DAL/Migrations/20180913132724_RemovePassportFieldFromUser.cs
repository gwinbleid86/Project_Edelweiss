using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class RemovePassportFieldFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportData",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CountQty",
                table: "Countries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountQty",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "PassportData",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
