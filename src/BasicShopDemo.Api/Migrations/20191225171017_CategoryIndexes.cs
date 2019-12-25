using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicShopDemo.Api.Migrations
{
    public partial class CategoryIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UI_CategoryCode",
                table: "Categories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_CategoryName",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UI_CategoryCode",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "UI_CategoryName",
                table: "Categories");
        }
    }
}
