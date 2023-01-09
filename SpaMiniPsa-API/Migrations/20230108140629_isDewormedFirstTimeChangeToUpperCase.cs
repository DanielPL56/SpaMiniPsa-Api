using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaMiniPsaAPI.Migrations
{
    /// <inheritdoc />
    public partial class isDewormedFirstTimeChangeToUpperCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDewormedFirstTime",
                table: "Dogs",
                newName: "IsDewormedFirstTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDewormedFirstTime",
                table: "Dogs",
                newName: "isDewormedFirstTime");
        }
    }
}
