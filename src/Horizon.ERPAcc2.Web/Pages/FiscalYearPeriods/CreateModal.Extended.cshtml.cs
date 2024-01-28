using Horizon.ERPAcc2.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Horizon.ERPAcc2.FiscalYearPeriods;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYearPeriods
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IFiscalYearPeriodsAppService fiscalYearPeriodsAppService)
            : base(fiscalYearPeriodsAppService)
        {
        }
    }
}