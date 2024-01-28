using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(FiscalYearConsts.FiscalYearNameMaxLength)]
        public string FiscalYearName { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public DateTime? LockDate { get; set; }
        [Required]
        public int CalanderYear { get; set; }
        [Required]
        public byte YearEndMonth { get; set; }
        [Required]
        public byte YearEndDay { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
        [Required]
        public bool IsLocked { get; set; }
        [Required]
        public byte NoOfPeriods { get; set; }
        [Required]
        [StringLength(FiscalYearConsts.PeriodIntervalMaxLength)]
        public string PeriodInterval { get; set; } = null!;
        public int? FiscalYearStatusId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}