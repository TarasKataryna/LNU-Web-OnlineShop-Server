using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ImgMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Shirts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Hoodies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Img = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_ImageId",
                table: "Shirts",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoodies_ImageId",
                table: "Hoodies",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoodies_Images_ImageId",
                table: "Hoodies",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shirts_Images_ImageId",
                table: "Shirts",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoodies_Images_ImageId",
                table: "Hoodies");

            migrationBuilder.DropForeignKey(
                name: "FK_Shirts_Images_ImageId",
                table: "Shirts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Shirts_ImageId",
                table: "Shirts");

            migrationBuilder.DropIndex(
                name: "IX_Hoodies_ImageId",
                table: "Hoodies");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Shirts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Hoodies");
        }
    }
}
