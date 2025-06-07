using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace globalsolution.Migrations
{
    /// <inheritdoc />
    public partial class AlterarString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Relatos");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Relatos");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Relatos",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(9,6)",
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Relatos",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(9,6)",
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Relatos",
                type: "DECIMAL(9,6)",
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Relatos",
                type: "DECIMAL(9,6)",
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Relatos",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Relatos",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }
    }
}
