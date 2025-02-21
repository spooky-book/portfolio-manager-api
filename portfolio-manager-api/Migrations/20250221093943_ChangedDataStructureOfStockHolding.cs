using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDataStructureOfStockHolding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Assets",
                newName: "AcquisitionPrice");

            migrationBuilder.RenameColumn(
                name: "PurchaseDateTime",
                table: "Assets",
                newName: "AcquisitionDateTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsDisposed",
                table: "Assets",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisposed",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "AcquisitionPrice",
                table: "Assets",
                newName: "PurchasePrice");

            migrationBuilder.RenameColumn(
                name: "AcquisitionDateTime",
                table: "Assets",
                newName: "PurchaseDateTime");
        }
    }
}
