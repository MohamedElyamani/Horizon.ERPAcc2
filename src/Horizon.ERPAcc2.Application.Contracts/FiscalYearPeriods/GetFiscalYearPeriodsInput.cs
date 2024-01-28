using Volo.Abp.Application.Dtos;
using System;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public abstract class GetFiscalYearPeriodsInputBase : PagedAndSortedResultRequestDto
    {
        public Guid? FiscalYearId { get; set; }

        public string? FilterText { get; set; }

        public string? PeriodName { get; set; }
        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public DateTime? StartDateMin { get; set; }
        public DateTime? StartDateMax { get; set; }
        public DateTime? EndDateMin { get; set; }
        public DateTime? EndDateMax { get; set; }
        public int? PeriodStatusIdMin { get; set; }
        public int? PeriodStatusIdMax { get; set; }
        public bool? IsClosed { get; set; }
        public DateTime? CloseDateMin { get; set; }
        public DateTime? CloseDateMax { get; set; }
        public decimal? TotalDepitMin { get; set; }
        public decimal? TotalDepitMax { get; set; }
        public decimal? TotalCreditMin { get; set; }
        public decimal? TotalCreditMax { get; set; }
        public decimal? ClosingBalanceMin { get; set; }
        public decimal? ClosingBalanceMax { get; set; }
        public decimal? BeginingInventoryMin { get; set; }
        public decimal? BeginingInventoryMax { get; set; }
        public decimal? PurchasesMin { get; set; }
        public decimal? PurchasesMax { get; set; }
        public decimal? EndiningInventoryMin { get; set; }
        public decimal? EndiningInventoryMax { get; set; }
        public decimal? COGSMin { get; set; }
        public decimal? COGSMax { get; set; }

        public GetFiscalYearPeriodsInputBase()
        {

        }
    }
}