using Microsoft.EntityFrameworkCore.Migrations;

namespace BTO.SmartHomeDatas.Migrations
{
    public partial class Mg_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcType",
                table: "t_Cards",
                newName: "ModeType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModeType",
                table: "t_Cards",
                newName: "ProcType");
        }
    }
}
