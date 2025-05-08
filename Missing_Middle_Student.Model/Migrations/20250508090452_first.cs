using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Missing_Middle_Student.Model.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Devices",
                newName: "Model");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Devices",
                newName: "Name");
        }
    }
}
