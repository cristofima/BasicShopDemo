using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BasicShopDemo.Api.Migrations.ApplicationDb
{
    public partial class Logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Headers = table.Column<string>(nullable: false),
                    Method = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Path = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    QueryString = table.Column<string>(nullable: true),
                    RequestBody = table.Column<string>(nullable: true),
                    Host = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ClientIp = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    ResponseTime = table.Column<long>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
