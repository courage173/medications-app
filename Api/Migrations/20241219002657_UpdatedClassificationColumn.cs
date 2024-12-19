using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClassificationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Classifications_ClassificationId",
                table: "Medications");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropIndex(
                name: "IX_Medications_ClassificationId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Medications");

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Medications");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_ClassificationId",
                table: "Medications",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Classifications_Name",
                table: "Classifications",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Classifications_ClassificationId",
                table: "Medications",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
