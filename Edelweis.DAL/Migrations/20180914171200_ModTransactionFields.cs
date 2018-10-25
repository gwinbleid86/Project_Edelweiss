using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class ModTransactionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentFromCommission",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentToCommission",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemCommission",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentFromCommission",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AgentToCommission",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SystemCommission",
                table: "Transactions");
        }
    }
}
