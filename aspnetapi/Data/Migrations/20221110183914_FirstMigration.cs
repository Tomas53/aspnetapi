using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aspnetapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 1000000, nullable: false),
                    Price = table.Column<string>(type: "TEXT", maxLength: 1000000, nullable: false),
                    Data = table.Column<string>(type: "TEXT", maxLength: 1000000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Country", "Data", "Price", "StockName" },
                values: new object[,]
                {
                    { 1, "Stock 1 country", "Stock 1 was bought on 2022.11.11", "Stock 1 price", "Stock 1 name" },
                    { 2, "Stock 2 country", "Stock 2 was bought on 2022.11.11", "Stock 2 price", "Stock 2 name" },
                    { 3, "Stock 3 country", "Stock 3 was bought on 2022.11.11", "Stock 3 price", "Stock 3 name" },
                    { 4, "Stock 4 country", "Stock 4 was bought on 2022.11.11", "Stock 4 price", "Stock 4 name" },
                    { 5, "Stock 5 country", "Stock 5 was bought on 2022.11.11", "Stock 5 price", "Stock 5 name" },
                    { 6, "Stock 6 country", "Stock 6 was bought on 2022.11.11", "Stock 6 price", "Stock 6 name" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
