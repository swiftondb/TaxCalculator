using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.Infrastructure.Migrations
{
    public partial class TaxBandInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "LowerLimit", "TaxBandName", "TaxRate", "UpperLimit" },
                values: new object[] { 1, 0, "Tax Band A", 0, 5000 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "LowerLimit", "TaxBandName", "TaxRate", "UpperLimit" },
                values: new object[] { 2, 5000, "Tax Band B", 20, 20000 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "LowerLimit", "TaxBandName", "TaxRate", "UpperLimit" },
                values: new object[] { 3, 20000, "Tax Band C", 40, null });
        }

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
