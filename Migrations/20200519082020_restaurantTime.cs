using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace newProjectJs.Migrations
{
    public partial class restaurantTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));
        }
    }
}
