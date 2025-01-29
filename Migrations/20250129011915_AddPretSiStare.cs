using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriBiciclete.Migrations
{
    /// <inheritdoc />
    public partial class AddPretSiStare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibila",
                table: "Biciclete");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Biciclete",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Biciclete",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Pret",
                table: "Biciclete",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Stare",
                table: "Biciclete",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Biciclete");

            migrationBuilder.DropColumn(
                name: "Stare",
                table: "Biciclete");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Biciclete",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Biciclete",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "Disponibila",
                table: "Biciclete",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
