using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaMiniPsaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "Dogs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Dogs");
        }
    }
}
