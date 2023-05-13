using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class updatecarservicerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_CarServices_CarServiceId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CarServiceId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CarServiceId",
                table: "Brands");

            migrationBuilder.AddColumn<int>(
                name: "MainBrandId",
                table: "CarServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_MainBrandId",
                table: "CarServices",
                column: "MainBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarServices_Brands_MainBrandId",
                table: "CarServices",
                column: "MainBrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarServices_Brands_MainBrandId",
                table: "CarServices");

            migrationBuilder.DropIndex(
                name: "IX_CarServices_MainBrandId",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "MainBrandId",
                table: "CarServices");

            migrationBuilder.AddColumn<int>(
                name: "CarServiceId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CarServiceId",
                table: "Brands",
                column: "CarServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_CarServices_CarServiceId",
                table: "Brands",
                column: "CarServiceId",
                principalTable: "CarServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
