using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDataTypesForStockHoldings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellTime",
                table: "Assets",
                newName: "DisposalDateTime");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Assets",
                newName: "DisposalPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisposalPrice",
                table: "Assets",
                newName: "SellPrice");

            migrationBuilder.RenameColumn(
                name: "DisposalDateTime",
                table: "Assets",
                newName: "SellTime");
        }
    }
}
