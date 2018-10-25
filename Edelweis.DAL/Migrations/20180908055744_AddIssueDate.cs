using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class AddIssueDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDateLocal",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDateUtc",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueDateLocal",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IssueDateUtc",
                table: "Transactions");
        }
    }
}
