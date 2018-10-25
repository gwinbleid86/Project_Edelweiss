using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class AddRangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RangeId",
                table: "Tariffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Tariffs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Ranges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RangeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranges", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_RangeId",
                table: "Tariffs",
                column: "RangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Ranges_RangeId",
                table: "Tariffs",
                column: "RangeId",
                principalTable: "Ranges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Ranges_RangeId",
                table: "Tariffs");

            migrationBuilder.DropTable(
                name: "Ranges");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_RangeId",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "RangeId",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Tariffs");
        }
    }
}
