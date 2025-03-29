using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class Modified12313 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcquisitionDateTime",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "AcquisitionPrice",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "DisposalDateTime",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IsDisposed",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "DisposalPrice",
                table: "Assets",
                newName: "TotalQuantity");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Assets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransactionType = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    TotalAcquisitionPrice = table.Column<double>(type: "REAL", nullable: true),
                    AcquisitionDateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    AcquisitionUnitPrice = table.Column<double>(type: "REAL", nullable: true),
                    AcquisitionBrokerageFee = table.Column<double>(type: "REAL", nullable: true),
                    IsDisposed = table.Column<bool>(type: "INTEGER", nullable: true),
                    DisposalDateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    DisposalPrice = table.Column<double>(type: "REAL", nullable: true),
                    StockHoldingId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Assets_StockHoldingId",
                        column: x => x.StockHoldingId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StockHoldingId",
                table: "Transactions",
                column: "StockHoldingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                table: "Assets",
                newName: "DisposalPrice");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Assets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AcquisitionDateTime",
                table: "Assets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AcquisitionPrice",
                table: "Assets",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AveragePrice",
                table: "Assets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DisposalDateTime",
                table: "Assets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisposed",
                table: "Assets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Assets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
