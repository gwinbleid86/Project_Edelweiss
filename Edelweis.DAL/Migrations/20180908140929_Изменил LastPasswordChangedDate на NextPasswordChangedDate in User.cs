using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class ИзменилLastPasswordChangedDateнаNextPasswordChangedDateinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastPasswordChangedDate",
                table: "AspNetUsers",
                newName: "NextPasswordChangedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextPasswordChangedDate",
                table: "AspNetUsers",
                newName: "LastPasswordChangedDate");
        }
    }
}
