using Horizon.ERPAcc2.FiscalYearStatuses;

using System;
using System.Collections.Generic;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearWithNavigationPropertiesBase
    {
        public FiscalYear FiscalYear { get; set; } = null!;

        public FiscalYearStatus FiscalYearStatus { get; set; } = null!;
        

        
    }
}