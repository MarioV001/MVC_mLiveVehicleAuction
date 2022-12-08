using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mVehAuction.Data.Migrations
{
    public partial class LotLocationUPD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LotPhoneNum",
                table: "LotLocation",
                type: "int",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeneralManager",
                table: "LotLocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
