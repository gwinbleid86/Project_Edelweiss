using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class ChangeTransactionStatusToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "TransactionStatus",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Transactions");

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
        }
    }
}
