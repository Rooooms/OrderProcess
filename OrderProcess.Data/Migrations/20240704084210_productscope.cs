using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcess.Data.Migrations
{
    /// <inheritdoc />
    public partial class productscope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductScope",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealCode = table.Column<int>(type: "int", nullable: false),
                    DealDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductScopeJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductScope", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductScope");
        }
    }
}
