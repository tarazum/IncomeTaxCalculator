using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert initial data
            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "LowerLimit", "UpperLimit", "TaxRate" },
                values: new object[] { 0, 5000, 0 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "LowerLimit", "UpperLimit", "TaxRate" },
                values: new object[] { 5000, 20000, 20 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "LowerLimit", "UpperLimit", "TaxRate" },
                values: new object[] { 20000, null, 40 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
