using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public partial interface IFiscalYearPeriodsAppService : IApplicationService
    {
        Task<PagedResultDto<FiscalYearPeriodDto>> GetListByFiscalYearIdAsync(GetFiscalYearPeriodListInput input);

        Task<PagedResultDto<FiscalYearPeriodDto>> GetListAsync(GetFiscalYearPeriodsInput input);

        Task<FiscalYearPeriodDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<FiscalYearPeriodDto> CreateAsync(FiscalYearPeriodCreateDto input);

        Task<FiscalYearPeriodDto> UpdateAsync(Guid id, FiscalYearPeriodUpdateDto input);
    }
}