using Horizon.ERPAcc2.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Horizon.ERPAcc2.FiscalYearStatuses;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYearStatuses
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IFiscalYearStatusesAppService fiscalYearStatusesAppService)
            : base(fiscalYearStatusesAppService)
        {
        }
    }
}