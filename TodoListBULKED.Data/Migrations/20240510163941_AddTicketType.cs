using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListBULKED.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "PerformerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PerformerId",
                table: "Tickets",
                newName: "UserId");
        }
    }
}
