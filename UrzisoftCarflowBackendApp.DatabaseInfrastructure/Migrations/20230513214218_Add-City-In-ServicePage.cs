using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class AddCityInServicePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarServices_Cities_CityId",
                table: "CarServices");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "CarServices",
                newName: "CarServiceCityId");

            migrationBuilder.RenameIndex(
                name: "IX_CarServices_CityId",
                table: "CarServices",
                newName: "IX_CarServices_CarServiceCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarServices_Cities_CarServiceCityId",
                table: "CarServices",
                column: "CarServiceCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarServices_Cities_CarServiceCityId",
                table: "CarServices");

            migrationBuilder.RenameColumn(
                name: "CarServiceCityId",
                table: "CarServices",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_CarServices_CarServiceCityId",
                table: "CarServices",
                newName: "IX_CarServices_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarServices_Cities_CityId",
                table: "CarServices",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
