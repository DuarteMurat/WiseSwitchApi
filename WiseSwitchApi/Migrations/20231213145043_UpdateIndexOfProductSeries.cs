using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WiseSwitchApi.Migrations
{
    public partial class UpdateIndexOfProductSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductSeries_Name",
                table: "ProductSeries");

            migrationBuilder.DropIndex(
                name: "IX_ProductSeries_ProductLineId",
                table: "ProductSeries");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeries_ProductLineId_Name",
                table: "ProductSeries",
                columns: new[] { "ProductLineId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductSeries_ProductLineId_Name",
                table: "ProductSeries");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeries_Name",
                table: "ProductSeries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeries_ProductLineId",
                table: "ProductSeries",
                column: "ProductLineId");
        }
    }
}
