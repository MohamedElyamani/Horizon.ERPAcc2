using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public abstract class FiscalYearPeriodUpdateDtoBase
    {
        public Guid FiscalYearId { get; set; }
        [Required]
        [StringLength(FiscalYearPeriodConsts.PeriodNameMaxLength)]
        public string PeriodName { get; set; } = null!;
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int PeriodStatusId { get; set; }
        [Required]
        public bool IsClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        [Required]
        public decimal TotalDepit { get; set; }
        [Required]
        public decimal TotalCredit { get; set; }
        [Required]
        public decimal ClosingBalance { get; set; }
        [Required]
        public decimal BeginingInventory { get; set; }
        [Required]
        public decimal Purchases { get; set; }
        [Required]
        public decimal EndiningInventory { get; set; }
        [Required]
        public decimal COGS { get; set; }

    }
}