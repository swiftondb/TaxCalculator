using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaxBandName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LowerLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    UpperLimit = table.Column<int>(type: "INTEGER", nullable: true),
                    TaxRate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxBands_TaxBandName",
                table: "TaxBands",
                column: "TaxBandName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBands");
        }
    }
}
