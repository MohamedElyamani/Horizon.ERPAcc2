using Horizon.ERPAcc2.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Horizon.ERPAcc2.FiscalYearPeriods;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYearPeriods
{
    public abstract class EditModalModelBase : ERPAcc2PageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public FiscalYearPeriodUpdateViewModel FiscalYearPeriod { get; set; }

        protected IFiscalYearPeriodsAppService _fiscalYearPeriodsAppService;

        public EditModalModelBase(IFiscalYearPeriodsAppService fiscalYearPeriodsAppService)
        {
            _fiscalYearPeriodsAppService = fiscalYearPeriodsAppService;

            FiscalYearPeriod = new();
        }

        public virtual async Task OnGetAsync()
        {
            var fiscalYearPeriod = await _fiscalYearPeriodsAppService.GetAsync(Id);
            FiscalYearPeriod = ObjectMapper.Map<FiscalYearPeriodDto, FiscalYearPeriodUpdateViewModel>(fiscalYearPeriod);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _fiscalYearPeriodsAppService.UpdateAsync(Id, ObjectMapper.Map<FiscalYearPeriodUpdateViewModel, FiscalYearPeriodUpdateDto>(FiscalYearPeriod));
            return NoContent();
        }
    }

    public class FiscalYearPeriodUpdateViewModel : FiscalYearPeriodUpdateDto
    {
    }
}