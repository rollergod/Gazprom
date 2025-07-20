#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gazprom.API.Infrastructure
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1937, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota" },
                    { 2, new DateTime(1938, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung" },
                    { 3, new DateTime(1976, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple" },
                    { 4, new DateTime(1975, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microsoft" },
                    { 5, new DateTime(1946, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sony" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Mark", "Model", "RegistrationDate", "SupplierId" },
                values: new object[,]
                {
                    { 1, "Toyota", "Camry", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Toyota", "RAV4", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Samsung", "Galaxy S23", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "Apple", "iPhone 14", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, "Apple", "MacBook Pro", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, "Microsoft", "Surface Pro 9", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, "Sony", "PlayStation 5", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 8, "Sony", "WH-1000XM5", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SupplierId",
                table: "Offers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
