using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentService.Data.Migrations
{
    public partial class Nextchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuestName",
                table: "Reserevations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuestName",
                table: "Reserevations");
        }
    }
}
