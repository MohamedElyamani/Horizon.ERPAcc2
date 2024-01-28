using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public abstract class FiscalYearPeriodDtoBase : EntityDto<Guid>
    {
        public Guid FiscalYearId { get; set; }
        public string PeriodName { get; set; } = null!;
        public int CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PeriodStatusId { get; set; }
        public bool IsClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal TotalDepit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal BeginingInventory { get; set; }
        public decimal Purchases { get; set; }
        public decimal EndiningInventory { get; set; }
        public decimal COGS { get; set; }

    }
}