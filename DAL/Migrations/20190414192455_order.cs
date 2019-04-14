using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoodies_Orders_OrderId",
                table: "Hoodies");

            migrationBuilder.DropForeignKey(
                name: "FK_Shirts_Orders_OrderId",
                table: "Shirts");

            migrationBuilder.DropIndex(
                name: "IX_Shirts_OrderId",
                table: "Shirts");

            migrationBuilder.DropIndex(
                name: "IX_Hoodies_OrderId",
                table: "Hoodies");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Shirts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Hoodies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Shirts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Hoodies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_OrderId",
                table: "Shirts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoodies_OrderId",
                table: "Hoodies",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoodies_Orders_OrderId",
                table: "Hoodies",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shirts_Orders_OrderId",
                table: "Shirts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
