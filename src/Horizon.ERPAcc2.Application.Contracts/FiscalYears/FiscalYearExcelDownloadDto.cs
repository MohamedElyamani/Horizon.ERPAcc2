using Volo.Abp.Application.Dtos;
using System;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? FiscalYearName { get; set; }
        public DateTime? StartDateMin { get; set; }
        public DateTime? StartDateMax { get; set; }
        public DateTime? EndDateMin { get; set; }
        public DateTime? EndDateMax { get; set; }
        public DateTime? LockDateMin { get; set; }
        public DateTime? LockDateMax { get; set; }
        public int? CalanderYearMin { get; set; }
        public int? CalanderYearMax { get; set; }
        public byte? YearEndMonthMin { get; set; }
        public byte? YearEndMonthMax { get; set; }
        public byte? YearEndDayMin { get; set; }
        public byte? YearEndDayMax { get; set; }
        public bool? IsCurrent { get; set; }
        public bool? IsLocked { get; set; }
        public byte? NoOfPeriodsMin { get; set; }
        public byte? NoOfPeriodsMax { get; set; }
        public string? PeriodInterval { get; set; }
        public int? FiscalYearStatusId { get; set; }

        public FiscalYearExcelDownloadDtoBase()
        {

        }
    }
}