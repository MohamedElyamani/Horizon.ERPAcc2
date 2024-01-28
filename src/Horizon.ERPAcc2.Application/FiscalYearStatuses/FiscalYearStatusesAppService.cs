using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Horizon.ERPAcc2.Permissions;
using Horizon.ERPAcc2.FiscalYearStatuses;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Horizon.ERPAcc2.Shared;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{

    [Authorize(ERPAcc2Permissions.FiscalYearStatuses.Default)]
    public abstract class FiscalYearStatusesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<FiscalYearStatusExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IFiscalYearStatusRepository _fiscalYearStatusRepository;
        protected FiscalYearStatusManager _fiscalYearStatusManager;

        public FiscalYearStatusesAppServiceBase(IFiscalYearStatusRepository fiscalYearStatusRepository, FiscalYearStatusManager fiscalYearStatusManager, IDistributedCache<FiscalYearStatusExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _fiscalYearStatusRepository = fiscalYearStatusRepository;
            _fiscalYearStatusManager = fiscalYearStatusManager;
        }

        public virtual async Task<PagedResultDto<FiscalYearStatusDto>> GetListAsync(GetFiscalYearStatusesInput input)
        {
            var totalCount = await _fiscalYearStatusRepository.GetCountAsync(input.FilterText, input.FiscalYearStatusTitle);
            var items = await _fiscalYearStatusRepository.GetListAsync(input.FilterText, input.FiscalYearStatusTitle, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<FiscalYearStatusDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<FiscalYearStatus>, List<FiscalYearStatusDto>>(items)
            };
        }

        public virtual async Task<FiscalYearStatusDto> GetAsync(int id)
        {
            return ObjectMapper.Map<FiscalYearStatus, FiscalYearStatusDto>(await _fiscalYearStatusRepository.GetAsync(id));
        }

        [Authorize(ERPAcc2Permissions.FiscalYearStatuses.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _fiscalYearStatusRepository.DeleteAsync(id);
        }

        [Authorize(ERPAcc2Permissions.FiscalYearStatuses.Create)]
        public virtual async Task<FiscalYearStatusDto> CreateAsync(FiscalYearStatusCreateDto input)
        {

            var fiscalYearStatus = await _fiscalYearStatusManager.CreateAsync(
            input.FiscalYearStatusTitle
            );

            return ObjectMapper.Map<FiscalYearStatus, FiscalYearStatusDto>(fiscalYearStatus);
        }

        [Authorize(ERPAcc2Permissions.FiscalYearStatuses.Edit)]
        public virtual async Task<FiscalYearStatusDto> UpdateAsync(int id, FiscalYearStatusUpdateDto input)
        {

            var fiscalYearStatus = await _fiscalYearStatusManager.UpdateAsync(
            id,
            input.FiscalYearStatusTitle, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<FiscalYearStatus, FiscalYearStatusDto>(fiscalYearStatus);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(FiscalYearStatusExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _fiscalYearStatusRepository.GetListAsync(input.FilterText, input.FiscalYearStatusTitle);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<FiscalYearStatus>, List<FiscalYearStatusExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "FiscalYearStatuses.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new FiscalYearStatusExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}