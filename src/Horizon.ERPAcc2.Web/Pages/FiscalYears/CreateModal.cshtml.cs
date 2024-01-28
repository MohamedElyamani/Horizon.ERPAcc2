using Horizon.ERPAcc2.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Horizon.ERPAcc2.FiscalYears;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYears
{
    public abstract class CreateModalModelBase : ERPAcc2PageModel
    {

        [BindProperty]
        public FiscalYearCreateViewModel FiscalYear { get; set; }

        public List<SelectListItem> FiscalYearStatusLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(" — ", null)
        };

        protected IFiscalYearsAppService _fiscalYearsAppService;

        public CreateModalModelBase(IFiscalYearsAppService fiscalYearsAppService)
        {
            _fiscalYearsAppService = fiscalYearsAppService;

            FiscalYear = new();
        }

        public virtual async Task OnGetAsync()
        {
            FiscalYear = new FiscalYearCreateViewModel();
            FiscalYearStatusLookupList.AddRange((
                                    await _fiscalYearsAppService.GetFiscalYearStatusLookupAsync(new LookupRequestDto
                                    {
                                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
                        );

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _fiscalYearsAppService.CreateAsync(ObjectMapper.Map<FiscalYearCreateViewModel, FiscalYearCreateDto>(FiscalYear));
            return NoContent();
        }
    }

    public class FiscalYearCreateViewModel : FiscalYearCreateDto
    {
    }
}