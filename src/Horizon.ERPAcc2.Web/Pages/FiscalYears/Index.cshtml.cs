using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Horizon.ERPAcc2.FiscalYears;
using Horizon.ERPAcc2.Shared;

namespace Horizon.ERPAcc2.Web.Pages.FiscalYears
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public string? FiscalYearNameFilter { get; set; }
        public DateTime? StartDateFilterMin { get; set; }

        public DateTime? StartDateFilterMax { get; set; }
        public DateTime? EndDateFilterMin { get; set; }

        public DateTime? EndDateFilterMax { get; set; }
        public DateTime? LockDateFilterMin { get; set; }

        public DateTime? LockDateFilterMax { get; set; }
        public int? CalanderYearFilterMin { get; set; }

        public int? CalanderYearFilterMax { get; set; }
        public byte? YearEndMonthFilterMin { get; set; }

        public byte? YearEndMonthFilterMax { get; set; }
        public byte? YearEndDayFilterMin { get; set; }

        public byte? YearEndDayFilterMax { get; set; }
        [SelectItems(nameof(IsCurrentBoolFilterItems))]
        public string IsCurrentFilter { get; set; }

        public List<SelectListItem> IsCurrentBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        [SelectItems(nameof(IsLockedBoolFilterItems))]
        public string IsLockedFilter { get; set; }

        public List<SelectListItem> IsLockedBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        public byte? NoOfPeriodsFilterMin { get; set; }

        public byte? NoOfPeriodsFilterMax { get; set; }
        public string? PeriodIntervalFilter { get; set; }
        [SelectItems(nameof(FiscalYearStatusLookupList))]
        public int? FiscalYearStatusIdFilter { get; set; }
        public List<SelectListItem> FiscalYearStatusLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(string.Empty, null)
        };

        protected IFiscalYearsAppService _fiscalYearsAppService;

        public IndexModelBase(IFiscalYearsAppService fiscalYearsAppService)
        {
            _fiscalYearsAppService = fiscalYearsAppService;
        }

        public virtual async Task OnGetAsync()
        {
            FiscalYearStatusLookupList.AddRange((
                    await _fiscalYearsAppService.GetFiscalYearStatusLookupAsync(new LookupRequestDto
                    {
                        MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount
                    })).Items.Select(t => new SelectListItem(t.DisplayName, t.Id.ToString())).ToList()
            );

            await Task.CompletedTask;
        }
    }
}