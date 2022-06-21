using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class moezmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateNaisssance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "MyCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackagingType = table.Column<int>(type: "int", nullable: false),
                    DateProd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryFK = table.Column<int>(type: "int", nullable: true),
                    IsBiological = table.Column<int>(type: "int", nullable: false),
                    Herbs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LabeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_MyCategories_CategoryFK",
                        column: x => x.CategoryFK,
                        principalTable: "MyCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductFK = table.Column<int>(type: "int", nullable: false),
                    ClientFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => new { x.DateAchat, x.ClientFK, x.ProductFK });
                    table.ForeignKey(
                        name: "FK_Facture_Client_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Client",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facture_Products_ProductFK",
                        column: x => x.ProductFK,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Providings",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    ProvidersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providings", x => new { x.ProductsProductId, x.ProvidersId });
                    table.ForeignKey(
                        name: "FK_Providings_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Providings_Providers_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ClientFK",
                table: "Facture",
                column: "ClientFK");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ProductFK",
                table: "Facture",
                column: "ProductFK");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryFK",
                table: "Products",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_Providings_ProvidersId",
                table: "Providings",
                column: "ProvidersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "Providings");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "MyCategories");
        }
    }
}
