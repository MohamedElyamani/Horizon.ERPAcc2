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
    public abstract class EditModalModelBase : ERPAcc2PageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public FiscalYearUpdateViewModel FiscalYear { get; set; }

        public List<SelectListItem> FiscalYearStatusLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(" — ", null)
        };

        protected IFiscalYearsAppService _fiscalYearsAppService;

        public EditModalModelBase(IFiscalYearsAppService fiscalYearsAppService)
        {
            _fiscalYearsAppService = fiscalYearsAppService;

            FiscalYear = new();
        }

        public virtual async Task OnGetAsync()
        {
            var fiscalYearWithNavigationPropertiesDto = await _fiscalYearsAppService.GetWithNavigationPropertiesAsync(Id);
            FiscalYear = ObjectMapper.Map<FiscalYearDto, FiscalYearUpdateViewModel>(fiscalYearWithNavigationPropertiesDto.FiscalYear);

            FiscalYearStatusLookupList.AddRange((
                                    await _fiscalYearsAppService.GetFiscalYearStatusLookupAsync(new LookupRequestDto
                                    {
                                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
                        );

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _fiscalYearsAppService.UpdateAsync(Id, ObjectMapper.Map<FiscalYearUpdateViewModel, FiscalYearUpdateDto>(FiscalYear));
            return NoContent();
        }
    }

    public class FiscalYearUpdateViewModel : FiscalYearUpdateDto
    {
    }
}