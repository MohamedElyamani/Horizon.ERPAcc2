using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class FiscalYearStatusCreateDtoBase
    {
        [Required]
        [StringLength(FiscalYearStatusConsts.FiscalYearStatusTitleMaxLength)]
        public string FiscalYearStatusTitle { get; set; } = null!;
    }
}