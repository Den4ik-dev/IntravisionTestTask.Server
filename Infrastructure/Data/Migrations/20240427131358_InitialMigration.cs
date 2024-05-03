using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drinks",
                columns: table => new
                {
                    drink_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    quantity_in_machine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinks", x => x.drink_id);
                }
            );

            migrationBuilder.CreateTable(
                name: "machines_with_drinks",
                columns: table => new
                {
                    machine_with_drink_id = table.Column<int>(type: "int", nullable: false),
                    coins_quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machines_with_drinks", x => x.machine_with_drink_id);
                }
            );

            migrationBuilder.CreateTable(
                name: "nominals",
                columns: table => new
                {
                    nominal_id = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    is_blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nominals", x => x.nominal_id);
                }
            );

            migrationBuilder.InsertData(
                table: "machines_with_drinks",
                columns: new[] { "machine_with_drink_id", "coins_quantity" },
                values: new object[] { 1, 0 }
            );

            migrationBuilder.InsertData(
                table: "nominals",
                columns: new[] { "nominal_id", "is_blocked", "value" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 2, false, 2 },
                    { 3, false, 5 },
                    { 4, false, 10 }
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_drinks_image_path",
                table: "drinks",
                column: "image_path",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_drinks_name",
                table: "drinks",
                column: "name",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_nominals_value",
                table: "nominals",
                column: "value",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "drinks");

            migrationBuilder.DropTable(name: "machines_with_drinks");

            migrationBuilder.DropTable(name: "nominals");
        }
    }
}
