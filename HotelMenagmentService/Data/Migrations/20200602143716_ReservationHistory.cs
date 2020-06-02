using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentService.Data.Migrations
{
    public partial class ReservationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationHistoryItems",
                columns: table => new
                {
                    ReservationHistoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    check_in_History = table.Column<DateTime>(nullable: false),
                    check_out_History = table.Column<DateTime>(nullable: false),
                    GuestID_History = table.Column<int>(nullable: false),
                    GuestName_History = table.Column<string>(nullable: true),
                    RoomID_History = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationHistoryItems", x => x.ReservationHistoryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationHistoryItems");
        }
    }
}
