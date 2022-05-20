using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTO.SmartHomeDatas.Migrations
{
    public partial class Mg_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_IActionResults",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_IActionResults", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "t_IActionResultAuthenticationMaps",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    t_UserID = table.Column<int>(type: "int", nullable: false),
                    T_UsersObjectID = table.Column<int>(type: "int", nullable: true),
                    t_IActionResultID = table.Column<int>(type: "int", nullable: false),
                    t_IActionResultsObjectID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_IActionResultAuthenticationMaps", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_t_IActionResultAuthenticationMaps_t_IActionResults_t_IActionResultsObjectID",
                        column: x => x.t_IActionResultsObjectID,
                        principalTable: "t_IActionResults",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_IActionResultAuthenticationMaps_t_Users_T_UsersObjectID",
                        column: x => x.T_UsersObjectID,
                        principalTable: "t_Users",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_IActionResultAuthenticationMaps_t_IActionResultsObjectID",
                table: "t_IActionResultAuthenticationMaps",
                column: "t_IActionResultsObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_t_IActionResultAuthenticationMaps_T_UsersObjectID",
                table: "t_IActionResultAuthenticationMaps",
                column: "T_UsersObjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_IActionResultAuthenticationMaps");

            migrationBuilder.DropTable(
                name: "t_IActionResults");
        }
    }
}
