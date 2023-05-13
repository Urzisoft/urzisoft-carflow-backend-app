using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class updatepricesentitie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Fuels_FuelId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_FuelId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "FuelId",
                table: "Prices");

            migrationBuilder.AddColumn<string>(
                name: "Fuel",
                table: "Prices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "Prices");

            migrationBuilder.AddColumn<int>(
                name: "FuelId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_FuelId",
                table: "Prices",
                column: "FuelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Fuels_FuelId",
                table: "Prices",
                column: "FuelId",
                principalTable: "Fuels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
