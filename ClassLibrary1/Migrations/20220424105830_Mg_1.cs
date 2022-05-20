using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTO.SmartHomeDatas.Migrations
{
    public partial class Mg_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Cards",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SensorGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Cards", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "t_ConnectLogs",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAdress = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ConnectLogs", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "t_ExceptionLogs",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TactMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ExceptionLogs", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "t_Users",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Users", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "t_Pins",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PinNumber = table.Column<int>(type: "int", nullable: false),
                    InputOrOutput = table.Column<int>(type: "int", nullable: false),
                    ProcType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Pins", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_t_Pins_t_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "t_Cards",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_Pins_CardId",
                table: "t_Pins",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_ConnectLogs");

            migrationBuilder.DropTable(
                name: "t_ExceptionLogs");

            migrationBuilder.DropTable(
                name: "t_Pins");

            migrationBuilder.DropTable(
                name: "t_Users");

            migrationBuilder.DropTable(
                name: "t_Cards");
        }
    }
}
