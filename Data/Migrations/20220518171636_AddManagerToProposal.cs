using Microsoft.EntityFrameworkCore.Migrations;

namespace innovation_hub.Data.Migrations
{
    public partial class AddManagerToProposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Proposals",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_AppUsers_ManagerId",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_ManagerId",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Proposals");
        }
    }
}
