using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class add_rezervation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervation_AspNetUsers_AppUserId",
                table: "Rezervation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervation",
                table: "Rezervation");

            migrationBuilder.RenameTable(
                name: "Rezervation",
                newName: "Rezervations");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervation_AppUserId",
                table: "Rezervations",
                newName: "IX_Rezervations_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervations",
                table: "Rezervations",
                column: "ReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_AspNetUsers_AppUserId",
                table: "Rezervations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_AspNetUsers_AppUserId",
                table: "Rezervations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervations",
                table: "Rezervations");

            migrationBuilder.RenameTable(
                name: "Rezervations",
                newName: "Rezervation");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervations_AppUserId",
                table: "Rezervation",
                newName: "IX_Rezervation_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervation",
                table: "Rezervation",
                column: "ReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervation_AspNetUsers_AppUserId",
                table: "Rezervation",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
