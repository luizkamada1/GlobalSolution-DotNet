using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace globalsolution.Migrations
{
    /// <inheritdoc />
    public partial class AddMidiaUrlToRelato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MidiaUrl",
                table: "Relatos",
                type: "NVARCHAR2(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidiaUrl",
                table: "Relatos");
        }
    }
}
