using Microsoft.EntityFrameworkCore.Migrations;

namespace DojoTactics.Migrations
{
    public partial class _3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Matches_MatchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MatchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "OpponentId",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_OpponentId",
                table: "Matches",
                column: "OpponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_OpponentId",
                table: "Matches",
                column: "OpponentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_OpponentId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_OpponentId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "OpponentId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MatchId",
                table: "Users",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Matches_MatchId",
                table: "Users",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
