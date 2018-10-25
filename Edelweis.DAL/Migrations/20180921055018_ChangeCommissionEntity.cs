using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class ChangeCommissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AgentFromCommission",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "AgentToCommission",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "SystemCommission",
                table: "Commissions");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Commissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Commissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_AgentId",
                table: "Commissions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_TransactionId",
                table: "Commissions",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_Agents_AgentId",
                table: "Commissions",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_Transactions_TransactionId",
                table: "Commissions",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_Agents_AgentId",
                table: "Commissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_Transactions_TransactionId",
                table: "Commissions");

            migrationBuilder.DropIndex(
                name: "IX_Commissions_AgentId",
                table: "Commissions");

            migrationBuilder.DropIndex(
                name: "IX_Commissions_TransactionId",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Commissions");

            migrationBuilder.AddColumn<decimal>(
                name: "AgentFromCommission",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AgentToCommission",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SystemCommission",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AgentFromCommission",
                table: "Commissions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AgentToCommission",
                table: "Commissions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SystemCommission",
                table: "Commissions",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
