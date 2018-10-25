using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class removeSubAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Agents_AgentId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AgentId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "ParentAgentId",
                table: "Agents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentAgentId",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Agents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Agents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentId",
                table: "Agents",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Agents_AgentId",
                table: "Agents",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
