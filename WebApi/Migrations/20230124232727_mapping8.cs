using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mapping8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_BuyerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
