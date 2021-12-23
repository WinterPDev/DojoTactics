using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DojoTactics.Migrations
{
    public partial class _2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserInMatches_UserInMatchId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserInMatches");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserInMatchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserInMatchId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Users",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UserInMatchId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserInMatches",
                columns: table => new
                {
                    UserInMatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInMatches", x => x.UserInMatchId);
                    table.ForeignKey(
                        name: "FK_UserInMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserInMatchId",
                table: "Users",
                column: "UserInMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInMatches_MatchId",
                table: "UserInMatches",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserInMatches_UserInMatchId",
                table: "Users",
                column: "UserInMatchId",
                principalTable: "UserInMatches",
                principalColumn: "UserInMatchId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
