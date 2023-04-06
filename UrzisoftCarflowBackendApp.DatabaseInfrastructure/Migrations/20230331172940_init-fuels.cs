using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class initfuels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasStations_Gas_GasId",
                table: "GasStations");

            migrationBuilder.DropTable(
                name: "Gas");

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GasStations_Fuels_GasId",
                table: "GasStations",
                column: "GasId",
                principalTable: "Fuels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasStations_Fuels_GasId",
                table: "GasStations");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.CreateTable(
                name: "Gas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GasStations_Gas_GasId",
                table: "GasStations",
                column: "GasId",
                principalTable: "Gas",
                principalColumn: "Id");
        }
    }
}
