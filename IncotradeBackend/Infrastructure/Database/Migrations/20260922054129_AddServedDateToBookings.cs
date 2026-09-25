using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncotradeBackend.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddServedDateToBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ServedDate",
                table: "Bookings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServedDate",
                table: "Bookings");
        }
    }
}
