using Horizon.ERPAcc2.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Horizon.ERPAcc2.FiscalYearStatuses;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYearStatuses
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IFiscalYearStatusesAppService fiscalYearStatusesAppService)
            : base(fiscalYearStatusesAppService)
        {
        }
    }
}