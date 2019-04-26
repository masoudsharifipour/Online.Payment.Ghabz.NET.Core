using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online.Payment.Ghabz.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ghabzHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShenaseGhabz = table.Column<string>(nullable: false),
                    ShenasePardakht = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ghabzHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPayment = table.Column<bool>(nullable: false),
                    TrakingNumber = table.Column<string>(nullable: false),
                    GhabzHistoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paymentHistories_ghabzHistories_GhabzHistoryId",
                        column: x => x.GhabzHistoryId,
                        principalTable: "ghabzHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paymentHistories_GhabzHistoryId",
                table: "paymentHistories",
                column: "GhabzHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paymentHistories");

            migrationBuilder.DropTable(
                name: "ghabzHistories");
        }
    }
}
