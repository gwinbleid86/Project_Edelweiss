using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class addCountryToTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CountryId",
                table: "Transactions",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Countries_CountryId",
                table: "Transactions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Countries_CountryId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CountryId",
                table: "Transactions");
        }
    }
}
