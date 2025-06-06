using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddLicenseKeyToPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicenseKey",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseKey",
                table: "Purchases");
        }
    }
}
