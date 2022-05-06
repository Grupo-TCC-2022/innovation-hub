using Microsoft.EntityFrameworkCore.Migrations;

namespace innovation_hub.Data.Migrations
{
    public partial class RemovingNullableFromVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Votes",
                table: "Proposals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Votes",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Votes",
                table: "Proposals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Votes",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
