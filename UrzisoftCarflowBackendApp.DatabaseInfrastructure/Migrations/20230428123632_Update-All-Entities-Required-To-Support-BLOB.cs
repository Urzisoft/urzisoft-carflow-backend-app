using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Migrations
{
    public partial class UpdateAllEntitiesRequiredToSupportBLOB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageImageUrl",
                table: "GasStation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageImageUrl",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageImageUrl",
                table: "CarWashStations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageImageUrl",
                table: "CarServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageImageUrl",
                table: "GasStation");

            migrationBuilder.DropColumn(
                name: "StorageImageUrl",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StorageImageUrl",
                table: "CarWashStations");

            migrationBuilder.DropColumn(
                name: "StorageImageUrl",
                table: "CarServices");
        }
    }
}
