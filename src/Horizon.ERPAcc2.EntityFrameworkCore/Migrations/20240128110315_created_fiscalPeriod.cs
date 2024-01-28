using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizon.ERPAcc2.Migrations
{
    /// <inheritdoc />
    public partial class created_fiscalPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFiscalYearPeriod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FiscalYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodStatusId = table.Column<int>(type: "int", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalDepit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeginingInventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Purchases = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndiningInventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    COGS = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFiscalYearPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFiscalYearPeriod_AppFiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "AppFiscalYear",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFiscalYearPeriod_FiscalYearId",
                table: "AppFiscalYearPeriod",
                column: "FiscalYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFiscalYearPeriod");
        }
    }
}
