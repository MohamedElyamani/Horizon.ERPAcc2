using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Horizon.ERPAcc2.Shared;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public partial interface IFiscalYearStatusesAppService : IApplicationService
    {

        Task<PagedResultDto<FiscalYearStatusDto>> GetListAsync(GetFiscalYearStatusesInput input);

        Task<FiscalYearStatusDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<FiscalYearStatusDto> CreateAsync(FiscalYearStatusCreateDto input);

        Task<FiscalYearStatusDto> UpdateAsync(int id, FiscalYearStatusUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(FiscalYearStatusExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}