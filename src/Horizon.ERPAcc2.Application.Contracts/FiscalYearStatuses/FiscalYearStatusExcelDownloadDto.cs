using Volo.Abp.Application.Dtos;
using System;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class FiscalYearStatusExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? FiscalYearStatusTitle { get; set; }

        public FiscalYearStatusExcelDownloadDtoBase()
        {

        }
    }
}