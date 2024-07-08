using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcess.Data.Migrations
{
    /// <inheritdoc />
    public partial class dlno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dealno",
                table: "DealCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dealno",
                table: "DealCodes");
        }
    }
}
