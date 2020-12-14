using Microsoft.EntityFrameworkCore.Migrations;

namespace BetterBuys.Data.StoreMigrations
{
    public partial class AddBuyIdToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "Carts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Carts");
        }
    }
}
