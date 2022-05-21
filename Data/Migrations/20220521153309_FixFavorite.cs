using Microsoft.EntityFrameworkCore.Migrations;

namespace innovation_hub.Data.Migrations
{
    public partial class FixFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppUserProposalFavorite_AppUserId",
                table: "AppUserProposalFavorite",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserProposalFavorite_AppUsers_AppUserId",
                table: "AppUserProposalFavorite",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserProposalFavorite_AppUsers_AppUserId",
                table: "AppUserProposalFavorite");

            migrationBuilder.DropIndex(
                name: "IX_AppUserProposalFavorite_AppUserId",
                table: "AppUserProposalFavorite");
        }
    }
}
