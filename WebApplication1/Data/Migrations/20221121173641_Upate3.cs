using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mVehAuction.Data.Migrations
{
    public partial class Upate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Keys",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastBidderID",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RetailValue",
                table: "Vehicle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "LastBidderID",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "RetailValue",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Vehicle");

            migrationBuilder.AlterColumn<string>(
                name: "Keys",
                table: "Vehicle",
                type: "nvarchar(4)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
