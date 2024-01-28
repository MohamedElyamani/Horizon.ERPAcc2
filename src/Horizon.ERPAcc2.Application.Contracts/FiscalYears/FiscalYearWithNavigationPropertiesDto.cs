using Horizon.ERPAcc2.FiscalYearStatuses;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearWithNavigationPropertiesDtoBase
    {
        public FiscalYearDto FiscalYear { get; set; } = null!;

        public FiscalYearStatusDto FiscalYearStatus { get; set; } = null!;

    }
}