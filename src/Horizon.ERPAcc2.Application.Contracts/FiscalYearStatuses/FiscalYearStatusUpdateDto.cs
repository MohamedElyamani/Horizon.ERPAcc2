using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class FiscalYearStatusUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(FiscalYearStatusConsts.FiscalYearStatusTitleMaxLength)]
        public string FiscalYearStatusTitle { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;
    }
}