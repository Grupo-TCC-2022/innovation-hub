using Microsoft.EntityFrameworkCore.Migrations;

namespace innovation_hub.Data.Migrations
{
    public partial class FixProposalManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_AppUsers_ManagerId",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_ManagerId",
                table: "Proposals");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Proposals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Proposals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ManagerId",
                table: "Proposals",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_AppUsers_ManagerId",
                table: "Proposals",
                column: "ManagerId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
