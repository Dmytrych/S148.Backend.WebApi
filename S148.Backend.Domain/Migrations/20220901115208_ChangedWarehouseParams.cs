using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S148.Backend.Domain.Migrations
{
    public partial class ChangedWarehouseParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WarehouseRef",
                table: "DeliveryInfo",
                newName: "WarehouseNumber");

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "DeliveryInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreaRef",
                table: "DeliveryInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityType",
                table: "DeliveryInfo",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "DeliveryInfo");

            migrationBuilder.DropColumn(
                name: "AreaRef",
                table: "DeliveryInfo");

            migrationBuilder.DropColumn(
                name: "CityType",
                table: "DeliveryInfo");

            migrationBuilder.RenameColumn(
                name: "WarehouseNumber",
                table: "DeliveryInfo",
                newName: "WarehouseRef");
        }
    }
}
