using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class AddCountryIdToTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Transactions");
        }
    }
}
