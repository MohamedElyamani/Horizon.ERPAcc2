using System;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearExcelDtoBase
    {
        public string FiscalYearName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? LockDate { get; set; }
        public int CalanderYear { get; set; }
        public byte YearEndMonth { get; set; }
        public byte YearEndDay { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsLocked { get; set; }
        public byte NoOfPeriods { get; set; }
        public string PeriodInterval { get; set; } = null!;
    }
}