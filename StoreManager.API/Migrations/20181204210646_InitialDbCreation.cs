using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManager.API.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    ProductGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.ProductGroupId);
                    table.ForeignKey(
                        name: "FK_ProductGroups_ProductGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 150, nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStores",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceWithVaT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VatRate = table.Column<decimal>(type: "decimal(6,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStores", x => new { x.ProductId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_ProductStores_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "ProductGroupId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Group 1", null },
                    { 2, "Group 2", null },
                    { 3, "Group 3", null },
                    { 4, "Group 4", null },
                    { 5, "Group 5", null },
                    { 6, "Group 6", null },
                    { 7, "Group 7", null },
                    { 8, "Group 8", null }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Store 1" },
                    { 2, "Store 2" },
                    { 3, "Store 3" },
                    { 4, "Store 4" },
                    { 5, "Store 5" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DateAdded", "ProductGroupId", "ProductName" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 1, "Product 1" },
                    { 5, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 1, "Product 5" },
                    { 2, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 2, "Product 2" },
                    { 3, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 2, "Product 3" },
                    { 4, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 2, "Product 4" },
                    { 6, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 3, "Product 6" },
                    { 7, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 3, "Product 7" },
                    { 8, new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), 3, "Product 8" }
                });

            migrationBuilder.InsertData(
                table: "ProductStores",
                columns: new[] { "ProductId", "StoreId", "Price", "PriceWithVaT", "VatRate" },
                values: new object[,]
                {
                    { 1, 1, 12.00m, 13.20m, 0.32m },
                    { 1, 2, 50.00m, 15.20m, 0.36m },
                    { 1, 3, 48.00m, 14.20m, 0.63m },
                    { 1, 4, 50.00m, 19.20m, 0.54m },
                    { 2, 2, 50.00m, 15.20m, 0.36m },
                    { 3, 2, 50.00m, 15.20m, 0.36m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_ParentId",
                table: "ProductGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_StoreId",
                table: "ProductStores",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStores");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
