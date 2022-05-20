using Microsoft.EntityFrameworkCore.Migrations;

namespace BTO.SmartHomeDatas.Migrations
{
    public partial class Mg_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_IActionResults_t_IActionResultsObjectID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.DropIndex(
                name: "IX_t_IActionResultAuthenticationMaps_t_IActionResultsObjectID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.DropColumn(
                name: "t_IActionResultsObjectID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.CreateIndex(
                name: "IX_t_IActionResultAuthenticationMaps_t_IActionResultID",
                table: "t_IActionResultAuthenticationMaps",
                column: "t_IActionResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_IActionResults_t_IActionResultID",
                table: "t_IActionResultAuthenticationMaps",
                column: "t_IActionResultID",
                principalTable: "t_IActionResults",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_IActionResults_t_IActionResultID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.DropIndex(
                name: "IX_t_IActionResultAuthenticationMaps_t_IActionResultID",
                table: "t_IActionResultAuthenticationMaps");

            migrationBuilder.AddColumn<int>(
                name: "t_IActionResultsObjectID",
                table: "t_IActionResultAuthenticationMaps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_IActionResultAuthenticationMaps_t_IActionResultsObjectID",
                table: "t_IActionResultAuthenticationMaps",
                column: "t_IActionResultsObjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_t_IActionResultAuthenticationMaps_t_IActionResults_t_IActionResultsObjectID",
                table: "t_IActionResultAuthenticationMaps",
                column: "t_IActionResultsObjectID",
                principalTable: "t_IActionResults",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
