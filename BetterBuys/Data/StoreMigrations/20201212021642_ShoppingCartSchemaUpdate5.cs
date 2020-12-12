using Microsoft.EntityFrameworkCore.Migrations;

namespace BetterBuys.Data.StoreMigrations
{
    public partial class ShoppingCartSchemaUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CheckoutInfos_CheckoutId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CheckoutId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "CheckoutInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutInfos_CartId",
                table: "CheckoutInfos",
                column: "CartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutInfos_Carts_CartId",
                table: "CheckoutInfos",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutInfos_Carts_CartId",
                table: "CheckoutInfos");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutInfos_CartId",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "CheckoutInfos");

            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CheckoutId",
                table: "Carts",
                column: "CheckoutId",
                unique: true,
                filter: "[CheckoutId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CheckoutInfos_CheckoutId",
                table: "Carts",
                column: "CheckoutId",
                principalTable: "CheckoutInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
