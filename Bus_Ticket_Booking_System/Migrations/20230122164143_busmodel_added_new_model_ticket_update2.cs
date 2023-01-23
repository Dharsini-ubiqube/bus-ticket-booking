using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bus_Ticket_Booking_System.Migrations
{
    public partial class busmodel_added_new_model_ticket_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "end",
                table: "Tickets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "start",
                table: "Tickets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Via",
                table: "Buses",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "seatsBtoVia",
                table: "Buses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "seatsViatoD",
                table: "Buses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buses_Via",
                table: "Buses",
                column: "Via");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Locations_Via",
                table: "Buses",
                column: "Via",
                principalTable: "Locations",
                principalColumn: "location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Locations_Via",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_Via",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "end",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "start",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Via",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "seatsBtoVia",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "seatsViatoD",
                table: "Buses");
        }
    }
}
