using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edelweiss.DAL.Migrations
{
    public partial class ModRangesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropColumn(
                name: "RangeDescription",
                table: "Ranges");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxValue",
                table: "Ranges",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinValue",
                table: "Ranges",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "Ranges");

            migrationBuilder.DropColumn(
                name: "MinValue",
                table: "Ranges");

            migrationBuilder.AddColumn<string>(
                name: "RangeDescription",
                table: "Ranges",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommissionValue = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    SysTransactionId = table.Column<int>(nullable: false),
                    AgentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_Transactions_SysTransactionId",
                        column: x => x.SysTransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_AgentId",
                table: "Commissions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_SysTransactionId",
                table: "Commissions",
                column: "SysTransactionId");
        }
    }
}
