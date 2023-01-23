using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bus_Ticket_Booking_System.Migrations
{
    public partial class busmodel_added_new_model_and_foreign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardingLocation",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DestinationLocation",
                table: "Buses");

            migrationBuilder.AlterColumn<string>(
                name: "location",
                table: "Locations",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "BoardingLocationid",
                table: "Buses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationid",
                table: "Buses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BoardingLocationid",
                table: "Buses",
                column: "BoardingLocationid");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DestinationLocationid",
                table: "Buses",
                column: "DestinationLocationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Locations_BoardingLocationid",
                table: "Buses",
                column: "BoardingLocationid",
                principalTable: "Locations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Locations_DestinationLocationid",
                table: "Buses",
                column: "DestinationLocationid",
                principalTable: "Locations",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Locations_BoardingLocationid",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Locations_DestinationLocationid",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_BoardingLocationid",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_DestinationLocationid",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "BoardingLocationid",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DestinationLocationid",
                table: "Buses");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "location",
                keyValue: null,
                column: "location",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "location",
                table: "Locations",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BoardingLocation",
                table: "Buses",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DestinationLocation",
                table: "Buses",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
