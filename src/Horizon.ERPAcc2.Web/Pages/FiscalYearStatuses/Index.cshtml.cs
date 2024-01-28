using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Horizon.ERPAcc2.FiscalYearStatuses;
using Horizon.ERPAcc2.Shared;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYearStatuses
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public string? FiscalYearStatusTitleFilter { get; set; }

        protected IFiscalYearStatusesAppService _fiscalYearStatusesAppService;

        public IndexModelBase(IFiscalYearStatusesAppService fiscalYearStatusesAppService)
        {
            _fiscalYearStatusesAppService = fiscalYearStatusesAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}