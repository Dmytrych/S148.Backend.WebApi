using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace S148.Backend.Domain.Migrations
{
    public partial class AddedDeliveryInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryInfoId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeliveryInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    CityRef = table.Column<string>(type: "text", nullable: false),
                    WarehouseRef = table.Column<string>(type: "text", nullable: false),
                    WarehouseDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryInfoId",
                table: "Orders",
                column: "DeliveryInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryInfo_DeliveryInfoId",
                table: "Orders",
                column: "DeliveryInfoId",
                principalTable: "DeliveryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryInfo_DeliveryInfoId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryInfo");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryInfoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryInfoId",
                table: "Orders");
        }
    }
}
