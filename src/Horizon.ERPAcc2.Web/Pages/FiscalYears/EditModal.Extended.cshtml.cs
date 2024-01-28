using Horizon.ERPAcc2.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Horizon.ERPAcc2.FiscalYears;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYears
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IFiscalYearsAppService fiscalYearsAppService)
            : base(fiscalYearsAppService)
        {
        }
    }
}