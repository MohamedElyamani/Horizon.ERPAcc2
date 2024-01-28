using Volo.Abp.Application.Dtos;
using System;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public class GetFiscalYearPeriodListInput : PagedAndSortedResultRequestDto
    {
        public Guid FiscalYearId { get; set; }
    }
}