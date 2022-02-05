using Microsoft.EntityFrameworkCore.Migrations;

namespace Conveyor.DataAccess.Migrations
{
    public partial class DefaultMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConveyorBelts");

            migrationBuilder.DropTable(
                name: "MetallCostings");

            migrationBuilder.DropTable(
                name: "Motovarios");

            migrationBuilder.DropTable(
                name: "Sews");

            migrationBuilder.DropTable(
                name: "BeltTypes");
        }
    }
}
