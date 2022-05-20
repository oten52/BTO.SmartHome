using Microsoft.EntityFrameworkCore.Migrations;

namespace BTO.SmartHomeDatas.Migrations
{
    public partial class Mg_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_Users_T_UsersObjectID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.DropIndex(
                name: "IX_t_IActionResultAuthenticationMaps_T_UsersObjectID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.DropColumn(
                name: "T_UsersObjectID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.CreateIndex(
                name: "IX_t_IActionResultAuthenticationMaps_t_UserID",
                table: "t_IActionResultAuthenticationMaps",
                column: "t_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_Users_t_UserID",
                table: "t_IActionResultAuthenticationMaps",
                column: "t_UserID",
                principalTable: "t_Users",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_Users_t_UserID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.DropIndex(
                name: "IX_t_IActionResultAuthenticationMaps_t_UserID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.AddColumn<int>(
                name: "T_UsersObjectID",
                table: "t_IActionResultAuthenticationMaps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_IActionResultAuthenticationMaps_T_UsersObjectID",
                table: "t_IActionResultAuthenticationMaps",
                column: "T_UsersObjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_Users_T_UsersObjectID",
                table: "t_IActionResultAuthenticationMaps",
                column: "T_UsersObjectID",
                principalTable: "t_Users",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
