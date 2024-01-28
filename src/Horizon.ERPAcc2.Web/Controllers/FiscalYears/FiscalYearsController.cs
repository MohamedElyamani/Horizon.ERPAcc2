using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Horizon.ERPAcc2.Web.Controllers.FiscalYears;

[Route("[controller]/[action]")]
public class FiscalYearsController : AbpController
{
    [HttpGet]
    public virtual async Task<PartialViewResult> ChildDataGrid(Guid fiscalYearId)
    {
        return PartialView("~/Pages/Shared/FiscalYears/_ChildDataGrids.cshtml", fiscalYearId);
    }
}