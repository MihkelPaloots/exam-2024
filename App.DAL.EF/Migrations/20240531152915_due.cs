using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.DAL.EF.Migrations
{
    /// <inheritdoc />
    public partial class due : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMarks",
                table: "Homeworks");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Homeworks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Homeworks");

            migrationBuilder.AddColumn<int>(
                name: "TotalMarks",
                table: "Homeworks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
