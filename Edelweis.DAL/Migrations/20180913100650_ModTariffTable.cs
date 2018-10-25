using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class ModTariffTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tariffs_AgentId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CurrencyId",
                table: "Tariffs");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_AgentId",
                table: "Tariffs",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CurrencyId",
                table: "Tariffs",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tariffs_AgentId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CurrencyId",
                table: "Tariffs");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_AgentId",
                table: "Tariffs",
                column: "AgentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CurrencyId",
                table: "Tariffs",
                column: "CurrencyId",
                unique: true);
        }
    }
}
