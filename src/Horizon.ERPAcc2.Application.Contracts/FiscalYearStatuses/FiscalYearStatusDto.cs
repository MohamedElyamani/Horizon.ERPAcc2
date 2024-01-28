using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class FiscalYearStatusDtoBase : AuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string FiscalYearStatusTitle { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;

    }
}