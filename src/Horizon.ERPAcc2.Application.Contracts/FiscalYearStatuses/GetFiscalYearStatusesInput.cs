using Volo.Abp.Application.Dtos;
using System;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class GetFiscalYearStatusesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? FiscalYearStatusTitle { get; set; }

        public GetFiscalYearStatusesInputBase()
        {

        }
    }
}