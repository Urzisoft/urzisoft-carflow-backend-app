using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class addpriceaslistinfuelspartthree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Fuels_FuelId",
                table: "Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                table: "Price");

            migrationBuilder.RenameTable(
                name: "Price",
                newName: "Prices");

            migrationBuilder.RenameIndex(
                name: "IX_Price_FuelId",
                table: "Prices",
                newName: "IX_Prices_FuelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Fuels_FuelId",
                table: "Prices",
                column: "FuelId",
                principalTable: "Fuels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Fuels_FuelId",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_FuelId",
                table: "Price",
                newName: "IX_Price_FuelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                table: "Price",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Fuels_FuelId",
                table: "Price",
                column: "FuelId",
                principalTable: "Fuels",
                principalColumn: "Id");
        }
    }
}
