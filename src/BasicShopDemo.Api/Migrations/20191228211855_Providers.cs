using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicShopDemo.Api.Migrations
{
    public partial class Providers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(6,2)",
                nullable: false,
                defaultValue: 0.05m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(6,2)");

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RUC = table.Column<string>(type: "VARCHAR(13)", nullable: false),
                    BusinessName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    CellPhone = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    WebSite = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvidersCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidersCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvidersCategories_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice",
                table: "Products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "UI_ProviderBusinessName",
                table: "Providers",
                column: "BusinessName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_ProviderCellPhone",
                table: "Providers",
                column: "CellPhone",
                unique: true,
                filter: "([CellPhone] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UI_ProviderEmail",
                table: "Providers",
                column: "Email",
                unique: true,
                filter: "([Email] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UI_ProviderPhone",
                table: "Providers",
                column: "Phone",
                unique: true,
                filter: "([Phone] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UI_ProviderRUC",
                table: "Providers",
                column: "RUC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_ProviderWebSite",
                table: "Providers",
                column: "WebSite",
                unique: true,
                filter: "([WebSite] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersCategories_CategoryId",
                table: "ProvidersCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UI_ProviderCategory",
                table: "ProvidersCategories",
                columns: new[] { "ProviderId", "CategoryId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidersCategories");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_ProductPrice",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(6,2)",
                oldDefaultValue: 0.05m);
        }
    }
}
