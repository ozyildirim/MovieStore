using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mapping7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MovieId",
                table: "Orders",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Movies_MovieId",
                table: "Orders",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_BuyerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Movies_MovieId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MovieId",
                table: "Orders");
        }
    }
}
