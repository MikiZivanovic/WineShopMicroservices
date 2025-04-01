using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountGRPC.Migrations
{
    /// <inheritdoc />
    public partial class IzmenaInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductName",
                value: "Pinot Noir Elegance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductName",
                value: "Pinot Noir Eleganc");
        }
    }
}
