using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaMiniPsaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dogs",
                table: "dogs");

            migrationBuilder.RenameTable(
                name: "dogs",
                newName: "Dogs");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Dogs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Dogs");

            migrationBuilder.RenameTable(
                name: "Dogs",
                newName: "dogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dogs",
                table: "dogs",
                column: "Id");
        }
    }
}
