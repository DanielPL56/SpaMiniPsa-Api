using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaMiniPsaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedBooleanIsDewormedFirstTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFirstDeworming",
                table: "dogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDewormedFirstTime",
                table: "dogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfFirstDeworming",
                table: "dogs");

            migrationBuilder.DropColumn(
                name: "isDewormedFirstTime",
                table: "dogs");
        }
    }
}
