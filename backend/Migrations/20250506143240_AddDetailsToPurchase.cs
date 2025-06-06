using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddDetailsToPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Purchases_PurchaseId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseId",
                table: "Purchases",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Purchases_PurchaseId",
                table: "Purchases",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");
        }
    }
}
