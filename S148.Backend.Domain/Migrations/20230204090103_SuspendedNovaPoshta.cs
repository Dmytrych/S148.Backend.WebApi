using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace S148.Backend.Domain.Migrations
{
    public partial class SuspendedNovaPoshta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovaPoshtaDeliveryInfo");

            migrationBuilder.DropColumn(
                name: "NovaPoshtaDeliveryInfo",
                table: "DeliveryInfo");

            migrationBuilder.DropColumn(
                name: "NovaPoshtaDeliveryInfoId",
                table: "DeliveryInfo");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DeliveryInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DeliveryInfo");

            migrationBuilder.AddColumn<int>(
                name: "NovaPoshtaDeliveryInfo",
                table: "DeliveryInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NovaPoshtaDeliveryInfoId",
                table: "DeliveryInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NovaPoshtaDeliveryInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaName = table.Column<string>(type: "text", nullable: false),
                    AreaRef = table.Column<Guid>(type: "uuid", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    CityRef = table.Column<Guid>(type: "uuid", nullable: false),
                    CityType = table.Column<string>(type: "text", nullable: false),
                    WarehouseDescription = table.Column<string>(type: "text", nullable: false),
                    WarehouseNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovaPoshtaDeliveryInfo", x => x.Id);
                });
        }
    }
}
