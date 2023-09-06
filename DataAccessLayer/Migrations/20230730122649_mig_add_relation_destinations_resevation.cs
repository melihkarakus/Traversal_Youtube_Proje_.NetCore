using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_relation_destinations_resevation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationsID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DestinationsID",
                table: "Reservations",
                column: "DestinationsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_DestinationsID",
                table: "Reservations",
                column: "DestinationsID",
                principalTable: "Destinations",
                principalColumn: "DestinationsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationsID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DestinationsID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DestinationsID",
                table: "Reservations");
        }
    }
}
