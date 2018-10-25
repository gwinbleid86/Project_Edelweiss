using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class AddedFieldsToTransactionAndTransactionCRUD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Created",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Issued",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ToPay",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ToPayOff",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ParentAgentId",
                table: "Agents",
                column: "ParentAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Agents_ParentAgentId",
                table: "Agents",
                column: "ParentAgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Agents_ParentAgentId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_ParentAgentId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Issued",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ToPay",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ToPayOff",
                table: "Transactions");
        }
    }
}
