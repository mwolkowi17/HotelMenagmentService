using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentService.Data.Migrations
{
    public partial class Modelbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    member_since = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "Reserevations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    check_in = table.Column<DateTime>(nullable: false),
                    check_out = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    made_by = table.Column<string>(nullable: true),
                    GuestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserevations", x => x.ReservationID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    is_ocuppied = table.Column<string>(nullable: true),
                    smoke = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Reserevations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
