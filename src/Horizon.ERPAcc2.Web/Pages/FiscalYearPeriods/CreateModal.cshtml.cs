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
    public abstract class CreateModalModelBase : ERPAcc2PageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid FiscalYearId { get; set; }

        [BindProperty]
        public FiscalYearPeriodCreateViewModel FiscalYearPeriod { get; set; }

        protected IFiscalYearPeriodsAppService _fiscalYearPeriodsAppService;

        public CreateModalModelBase(IFiscalYearPeriodsAppService fiscalYearPeriodsAppService)
        {
            _fiscalYearPeriodsAppService = fiscalYearPeriodsAppService;

            FiscalYearPeriod = new();
        }

        public virtual async Task OnGetAsync()
        {
            FiscalYearPeriod = new FiscalYearPeriodCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            FiscalYearPeriod.FiscalYearId = FiscalYearId;
            await _fiscalYearPeriodsAppService.CreateAsync(ObjectMapper.Map<FiscalYearPeriodCreateViewModel, FiscalYearPeriodCreateDto>(FiscalYearPeriod));
            return NoContent();
        }
    }

    public class FiscalYearPeriodCreateViewModel : FiscalYearPeriodCreateDto
    {
    }
}