using Microsoft.EntityFrameworkCore.Migrations;

namespace BetterBuys.Data.StoreMigrations
{
    public partial class ShoppingCartSchemaUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "Carts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CheckoutInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(nullable: false),
                    CardNumber = table.Column<string>(maxLength: 12, nullable: false),
                    CardHolderName = table.Column<string>(maxLength: 100, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 100, nullable: false),
                    CVW = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutInfos", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CheckoutInfos_CheckoutId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "CheckoutInfos");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CheckoutId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "CVW",
                table: "Carts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "Carts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Carts",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpirationDate",
                table: "Carts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
