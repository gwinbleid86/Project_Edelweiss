using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class AddFieldPassportDataInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassportData",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportData",
                table: "AspNetUsers");
        }
    }
}
