using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mVehAuction.Data.Migrations
{
    public partial class ADditional_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalDescription",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AuctionStartDate",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BodyStyle",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "BuyNow",
                table: "Vehicle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBid",
                table: "Vehicle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Drive",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EngineCC",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Keys",
                table: "Vehicle",
                type: "nvarchar(4)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LotLocation",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeCreated",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TransGears",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Transmision",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "VehDocuments",
                table: "Vehicle",
                type: "nvarchar(4)",
                nullable: false,
                defaultValue: "No");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalDescription",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AuctionStartDate",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BodyStyle",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BuyNow",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CurrentBid",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Drive",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "EngineCC",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Keys",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "LotLocation",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TransGears",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Transmision",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehDocuments",
                table: "Vehicle");
        }
    }
}
