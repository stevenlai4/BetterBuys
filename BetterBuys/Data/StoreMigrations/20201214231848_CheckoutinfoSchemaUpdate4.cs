using Microsoft.EntityFrameworkCore.Migrations;

namespace BetterBuys.Data.StoreMigrations
{
    public partial class CheckoutinfoSchemaUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVW",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "CheckoutInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "CheckoutInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "CheckoutInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CheckoutInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "CardHolderName",
                table: "CheckoutInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apartment",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "CheckoutInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "CheckoutInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "Apartment",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "City",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "CheckoutInfos");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "CheckoutInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "CheckoutInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "CheckoutInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CheckoutInfos",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardHolderName",
                table: "CheckoutInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CVW",
                table: "CheckoutInfos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "CheckoutInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
