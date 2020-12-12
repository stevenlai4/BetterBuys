using Microsoft.EntityFrameworkCore.Migrations;

namespace BetterBuys.Data.StoreMigrations
{
    public partial class ShoppingCartSchemaUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CheckoutInfos_CheckoutId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CheckoutId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CheckoutInfos_CheckoutId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CheckoutId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CheckoutId",
                table: "Carts",
                column: "CheckoutId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CheckoutInfos_CheckoutId",
                table: "Carts",
                column: "CheckoutId",
                principalTable: "CheckoutInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
