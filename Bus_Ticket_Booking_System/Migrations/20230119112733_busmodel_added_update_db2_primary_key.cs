using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bus_Ticket_Booking_System.Migrations
{
    public partial class busmodel_added_update_db2_primary_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Locations_BoardingLocationid",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Locations_DestinationLocationid",
                table: "Buses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

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
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "BoardingLocation",
                table: "Buses",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DestinationLocation",
                table: "Buses",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "location");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BoardingLocation",
                table: "Buses",
                column: "BoardingLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DestinationLocation",
                table: "Buses",
                column: "DestinationLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Locations_BoardingLocation",
                table: "Buses",
                column: "BoardingLocation",
                principalTable: "Locations",
                principalColumn: "location");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Locations_DestinationLocation",
                table: "Buses",
                column: "DestinationLocation",
                principalTable: "Locations",
                principalColumn: "location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Locations_BoardingLocation",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Locations_DestinationLocation",
                table: "Buses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Buses_BoardingLocation",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_DestinationLocation",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "BoardingLocation",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DestinationLocation",
                table: "Buses");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "location",
                table: "Locations",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "id");

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
    }
}
