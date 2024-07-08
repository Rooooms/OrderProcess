using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcess.Data.Migrations
{
    /// <inheritdoc />
    public partial class commit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "salesman",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DealCodeCustomerScope",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealCode = table.Column<int>(type: "int", nullable: false),
                    DealDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerScopeJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealCodeCustomerScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DealCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dealcode = table.Column<int>(type: "int", nullable: false),
                    DealDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    whseno = table.Column<int>(type: "int", nullable: false),
                    branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealStart = table.Column<DateOnly>(type: "date", nullable: false),
                    DealEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    rate = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    freegoods = table.Column<int>(type: "int", nullable: false),
                    minimumQty = table.Column<int>(type: "int", nullable: false),
                    dealType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealCodes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealCodeCustomerScope");

            migrationBuilder.DropTable(
                name: "DealCodes");

            migrationBuilder.DropColumn(
                name: "salesman",
                table: "Customers");
        }
    }
}
