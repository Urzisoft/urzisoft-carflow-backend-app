using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class addpriceaslistinfuelsparttwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Fuels_FuelId",
                table: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "FuelId",
                table: "Price",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Fuels_FuelId",
                table: "Price",
                column: "FuelId",
                principalTable: "Fuels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Fuels_FuelId",
                table: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "FuelId",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Fuels_FuelId",
                table: "Price",
                column: "FuelId",
                principalTable: "Fuels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
