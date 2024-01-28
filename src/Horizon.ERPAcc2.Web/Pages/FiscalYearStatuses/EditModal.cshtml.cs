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
    public abstract class EditModalModelBase : ERPAcc2PageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public FiscalYearStatusUpdateViewModel FiscalYearStatus { get; set; }

        protected IFiscalYearStatusesAppService _fiscalYearStatusesAppService;

        public EditModalModelBase(IFiscalYearStatusesAppService fiscalYearStatusesAppService)
        {
            _fiscalYearStatusesAppService = fiscalYearStatusesAppService;

            FiscalYearStatus = new();
        }

        public virtual async Task OnGetAsync()
        {
            var fiscalYearStatus = await _fiscalYearStatusesAppService.GetAsync(Id);
            FiscalYearStatus = ObjectMapper.Map<FiscalYearStatusDto, FiscalYearStatusUpdateViewModel>(fiscalYearStatus);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _fiscalYearStatusesAppService.UpdateAsync(Id, ObjectMapper.Map<FiscalYearStatusUpdateViewModel, FiscalYearStatusUpdateDto>(FiscalYearStatus));
            return NoContent();
        }
    }

    public class FiscalYearStatusUpdateViewModel : FiscalYearStatusUpdateDto
    {
    }
}