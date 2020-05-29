using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentService.Data.Migrations
{
    public partial class RoomIdinReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Reserevations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Reserevations");
        }
    }
}
