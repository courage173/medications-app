using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class updatedAtcCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ATCCodes",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_ATCCodes_Name",
                table: "ATCCodes",
                newName: "IX_ATCCodes_Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ATCCodes",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_ATCCodes_Code",
                table: "ATCCodes",
                newName: "IX_ATCCodes_Name");
        }
    }
}
