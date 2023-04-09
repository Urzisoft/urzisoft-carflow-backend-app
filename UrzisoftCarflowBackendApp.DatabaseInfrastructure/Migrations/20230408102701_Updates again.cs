using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class Updatesagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWashStations_Cities_LocationId",
                table: "CarWashStations");

            migrationBuilder.DropForeignKey(
                name: "FK_GasStations_Cities_LocationId",
                table: "GasStations");

            migrationBuilder.DropForeignKey(
                name: "FK_GasStations_Fuels_GasId",
                table: "GasStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GasStations",
                table: "GasStations");

            migrationBuilder.RenameTable(
                name: "GasStations",
                newName: "GasStation");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "CarWashStations",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_CarWashStations_LocationId",
                table: "CarWashStations",
                newName: "IX_CarWashStations_CityId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "GasStation",
                newName: "FuelId");

            migrationBuilder.RenameColumn(
                name: "GasId",
                table: "GasStation",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_GasStations_LocationId",
                table: "GasStation",
                newName: "IX_GasStation_FuelId");

            migrationBuilder.RenameIndex(
                name: "IX_GasStations_GasId",
                table: "GasStation",
                newName: "IX_GasStation_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GasStation",
                table: "GasStation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashStations_Cities_CityId",
                table: "CarWashStations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GasStation_Cities_CityId",
                table: "GasStation",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GasStation_Fuels_FuelId",
                table: "GasStation",
                column: "FuelId",
                principalTable: "Fuels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWashStations_Cities_CityId",
                table: "CarWashStations");

            migrationBuilder.DropForeignKey(
                name: "FK_GasStation_Cities_CityId",
                table: "GasStation");

            migrationBuilder.DropForeignKey(
                name: "FK_GasStation_Fuels_FuelId",
                table: "GasStation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GasStation",
                table: "GasStation");

            migrationBuilder.RenameTable(
                name: "GasStation",
                newName: "GasStations");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "CarWashStations",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CarWashStations_CityId",
                table: "CarWashStations",
                newName: "IX_CarWashStations_LocationId");

            migrationBuilder.RenameColumn(
                name: "FuelId",
                table: "GasStations",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "GasStations",
                newName: "GasId");

            migrationBuilder.RenameIndex(
                name: "IX_GasStation_FuelId",
                table: "GasStations",
                newName: "IX_GasStations_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_GasStation_CityId",
                table: "GasStations",
                newName: "IX_GasStations_GasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GasStations",
                table: "GasStations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashStations_Cities_LocationId",
                table: "CarWashStations",
                column: "LocationId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GasStations_Cities_LocationId",
                table: "GasStations",
                column: "LocationId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GasStations_Fuels_GasId",
                table: "GasStations",
                column: "GasId",
                principalTable: "Fuels",
                principalColumn: "Id");
        }
    }
}
