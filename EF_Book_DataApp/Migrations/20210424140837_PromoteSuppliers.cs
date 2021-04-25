using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Book_DataApp.Migrations
{
    public partial class PromoteSuppliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supplier_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_ContactDetails_ContactDetailsId",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameIndex(
                name: "IX_Supplier_ContactDetailsId",
                table: "Suppliers",
                newName: "IX_Suppliers_ContactDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_ContactDetails_ContactDetailsId",
                table: "Suppliers",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "ContactDetailsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_ContactDetails_ContactDetailsId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_ContactDetailsId",
                table: "Supplier",
                newName: "IX_Supplier_ContactDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supplier_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_ContactDetails_ContactDetailsId",
                table: "Supplier",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "ContactDetailsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
