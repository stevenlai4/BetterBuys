using Microsoft.EntityFrameworkCore.Migrations;

namespace BetterBuys.Data.StoreMigrations
{
    public partial class ShoppingCartSchemaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVW",
                table: "Carts",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "Carts",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Carts",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpirationDate",
                table: "Carts",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Carts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVW",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CardHolderName",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Carts");
        }
    }
}
