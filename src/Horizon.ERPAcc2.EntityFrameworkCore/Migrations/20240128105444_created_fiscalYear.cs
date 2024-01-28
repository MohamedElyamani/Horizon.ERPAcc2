using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizon.ERPAcc2.Migrations
{
    /// <inheritdoc />
    public partial class created_fiscalYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFiscalYear",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FiscalYearName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LockDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CalanderYear = table.Column<int>(type: "int", nullable: false),
                    YearEndMonth = table.Column<int>(type: "int", nullable: false),
                    YearEndDay = table.Column<int>(type: "int", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    NoOfPeriods = table.Column<int>(type: "int", nullable: false),
                    PeriodInterval = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FiscalYearStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFiscalYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFiscalYear_AppFiscalYearStatus_FiscalYearStatusId",
                        column: x => x.FiscalYearStatusId,
                        principalTable: "AppFiscalYearStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFiscalYear_FiscalYearStatusId",
                table: "AppFiscalYear",
                column: "FiscalYearStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFiscalYear");
        }
    }
}
