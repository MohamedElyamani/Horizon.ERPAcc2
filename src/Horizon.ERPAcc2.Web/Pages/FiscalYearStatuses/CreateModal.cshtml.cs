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
    public abstract class CreateModalModelBase : ERPAcc2PageModel
    {

        [BindProperty]
        public FiscalYearStatusCreateViewModel FiscalYearStatus { get; set; }

        protected IFiscalYearStatusesAppService _fiscalYearStatusesAppService;

        public CreateModalModelBase(IFiscalYearStatusesAppService fiscalYearStatusesAppService)
        {
            _fiscalYearStatusesAppService = fiscalYearStatusesAppService;

            FiscalYearStatus = new();
        }

        public virtual async Task OnGetAsync()
        {
            FiscalYearStatus = new FiscalYearStatusCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _fiscalYearStatusesAppService.CreateAsync(ObjectMapper.Map<FiscalYearStatusCreateViewModel, FiscalYearStatusCreateDto>(FiscalYearStatus));
            return NoContent();
        }
    }

    public class FiscalYearStatusCreateViewModel : FiscalYearStatusCreateDto
    {
    }
}