using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Book_DataApp.Migrations
{
    public partial class AdditionalTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContactDetailsId",
                table: "Supplier",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactLocation",
                columns: table => new
                {
                    ContactLocationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLocation", x => x.ContactLocationId);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationContactLocationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailsId);
                    table.ForeignKey(
                        name: "FK_ContactDetails_ContactLocation_LocationContactLocationId",
                        column: x => x.LocationContactLocationId,
                        principalTable: "ContactLocation",
                        principalColumn: "ContactLocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ContactDetailsId",
                table: "Supplier",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_LocationContactLocationId",
                table: "ContactDetails",
                column: "LocationContactLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_ContactDetails_ContactDetailsId",
                table: "Supplier",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "ContactDetailsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_ContactDetails_ContactDetailsId",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "ContactLocation");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ContactDetailsId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Supplier");
        }
    }
}
