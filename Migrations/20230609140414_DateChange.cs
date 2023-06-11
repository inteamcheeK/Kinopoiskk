using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoPoiskk.Migrations
{
    /// <inheritdoc />
    public partial class DateChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Actors",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DateOfBirth",
                table: "Actors",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
