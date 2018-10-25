using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class addPromoToAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePromo",
                table: "Agents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextPromo",
                table: "Agents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePromo",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "TextPromo",
                table: "Agents");
        }
    }
}
