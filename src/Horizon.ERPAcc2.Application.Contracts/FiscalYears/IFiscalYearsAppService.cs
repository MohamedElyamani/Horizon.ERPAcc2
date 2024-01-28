using Horizon.ERPAcc2.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Horizon.ERPAcc2.Shared;

namespace Horizon.ERPAcc2.FiscalYears
{
    public partial interface IFiscalYearsAppService : IApplicationService
    {

        Task<PagedResultDto<FiscalYearWithNavigationPropertiesDto>> GetListAsync(GetFiscalYearsInput input);

        Task<FiscalYearWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<FiscalYearDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<int>>> GetFiscalYearStatusLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<FiscalYearDto> CreateAsync(FiscalYearCreateDto input);

        Task<FiscalYearDto> UpdateAsync(Guid id, FiscalYearUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(FiscalYearExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}