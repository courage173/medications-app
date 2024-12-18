using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TherapeuticClasses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Form",
                table: "PharmaceuticalForms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ATCCodes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TherapeuticClasses_Name",
                table: "TherapeuticClasses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PharmaceuticalForms_Form",
                table: "PharmaceuticalForms",
                column: "Form",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classifications_Name",
                table: "Classifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ATCCodes_Name",
                table: "ATCCodes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TherapeuticClasses_Name",
                table: "TherapeuticClasses");

            migrationBuilder.DropIndex(
                name: "IX_PharmaceuticalForms_Form",
                table: "PharmaceuticalForms");

            migrationBuilder.DropIndex(
                name: "IX_Classifications_Name",
                table: "Classifications");

            migrationBuilder.DropIndex(
                name: "IX_ATCCodes_Name",
                table: "ATCCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TherapeuticClasses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Form",
                table: "PharmaceuticalForms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ATCCodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
