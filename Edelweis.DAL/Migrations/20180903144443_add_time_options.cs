using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class add_time_options : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Transactions",
                newName: "CreateDateUtc");

            migrationBuilder.RenameColumn(
                name: "ConfirmDate",
                table: "Transactions",
                newName: "ConfirmDateUtc");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmDateLocal",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateLocal",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmDateLocal",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreateDateLocal",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CreateDateUtc",
                table: "Transactions",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ConfirmDateUtc",
                table: "Transactions",
                newName: "ConfirmDate");
        }
    }
}
