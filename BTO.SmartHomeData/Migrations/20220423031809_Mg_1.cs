using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTO.SmartHomeData.Migrations
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
                name: "t_Sensors",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SensorGuid = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    PinNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Sensors", x => x.ObjectID);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Cards");

            migrationBuilder.DropTable(
                name: "t_ConnectLogs");

            migrationBuilder.DropTable(
                name: "t_ExceptionLogs");

            migrationBuilder.DropTable(
                name: "t_Sensors");

            migrationBuilder.DropTable(
                name: "t_Users");
        }
    }
}
