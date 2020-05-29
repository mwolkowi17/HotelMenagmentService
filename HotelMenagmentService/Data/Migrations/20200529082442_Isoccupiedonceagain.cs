using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentService.Data.Migrations
{
    public partial class Isoccupiedonceagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_ocuppied",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "is_ocuppied",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
