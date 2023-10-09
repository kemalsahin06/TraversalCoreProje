using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class eklemeislemi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationID",
                table: "Rezervations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervations_DestinationID",
                table: "Rezervations",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Destinations_DestinationID",
                table: "Rezervations",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Destinations_DestinationID",
                table: "Rezervations");

            migrationBuilder.DropIndex(
                name: "IX_Rezervations_DestinationID",
                table: "Rezervations");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "Rezervations");
        }
    }
}
