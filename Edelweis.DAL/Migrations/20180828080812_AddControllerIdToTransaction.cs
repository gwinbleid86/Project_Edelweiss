using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class AddControllerIdToTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ControllerId",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControllerId",
                table: "Transactions");
        }
    }
}
