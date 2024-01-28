using Horizon.ERPAcc2.FiscalYearStatuses;
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
using Horizon.ERPAcc2.FiscalYears;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Horizon.ERPAcc2.Shared;

namespace Horizon.ERPAcc2.FiscalYears
{

    [Authorize(ERPAcc2Permissions.FiscalYears.Default)]
    public abstract class FiscalYearsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<FiscalYearExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IFiscalYearRepository _fiscalYearRepository;
        protected FiscalYearManager _fiscalYearManager;
        protected IRepository<FiscalYearStatus, int> _fiscalYearStatusRepository;

        public FiscalYearsAppServiceBase(IFiscalYearRepository fiscalYearRepository, FiscalYearManager fiscalYearManager, IDistributedCache<FiscalYearExcelDownloadTokenCacheItem, string> excelDownloadTokenCache, IRepository<FiscalYearStatus, int> fiscalYearStatusRepository)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _fiscalYearRepository = fiscalYearRepository;
            _fiscalYearManager = fiscalYearManager; _fiscalYearStatusRepository = fiscalYearStatusRepository;
        }

        public virtual async Task<PagedResultDto<FiscalYearWithNavigationPropertiesDto>> GetListAsync(GetFiscalYearsInput input)
        {
            var totalCount = await _fiscalYearRepository.GetCountAsync(input.FilterText, input.FiscalYearName, input.StartDateMin, input.StartDateMax, input.EndDateMin, input.EndDateMax, input.LockDateMin, input.LockDateMax, input.CalanderYearMin, input.CalanderYearMax, input.YearEndMonthMin, input.YearEndMonthMax, input.YearEndDayMin, input.YearEndDayMax, input.IsCurrent, input.IsLocked, input.NoOfPeriodsMin, input.NoOfPeriodsMax, input.PeriodInterval, input.FiscalYearStatusId);
            var items = await _fiscalYearRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.FiscalYearName, input.StartDateMin, input.StartDateMax, input.EndDateMin, input.EndDateMax, input.LockDateMin, input.LockDateMax, input.CalanderYearMin, input.CalanderYearMax, input.YearEndMonthMin, input.YearEndMonthMax, input.YearEndDayMin, input.YearEndDayMax, input.IsCurrent, input.IsLocked, input.NoOfPeriodsMin, input.NoOfPeriodsMax, input.PeriodInterval, input.FiscalYearStatusId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<FiscalYearWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<FiscalYearWithNavigationProperties>, List<FiscalYearWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<FiscalYearWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<FiscalYearWithNavigationProperties, FiscalYearWithNavigationPropertiesDto>
                (await _fiscalYearRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<FiscalYearDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<FiscalYear, FiscalYearDto>(await _fiscalYearRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<int>>> GetFiscalYearStatusLookupAsync(LookupRequestDto input)
        {
            var query = (await _fiscalYearStatusRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Id != null &&
                         x.FiscalYearStatusTitle.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<FiscalYearStatus>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<int>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<FiscalYearStatus>, List<LookupDto<int>>>(lookupData)
            };
        }

        [Authorize(ERPAcc2Permissions.FiscalYears.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _fiscalYearRepository.DeleteAsync(id);
        }

        [Authorize(ERPAcc2Permissions.FiscalYears.Create)]
        public virtual async Task<FiscalYearDto> CreateAsync(FiscalYearCreateDto input)
        {

            var fiscalYear = await _fiscalYearManager.CreateAsync(
            input.FiscalYearStatusId, input.FiscalYearName, input.StartDate, input.EndDate, input.CalanderYear, input.YearEndMonth, input.YearEndDay, input.IsCurrent, input.IsLocked, input.NoOfPeriods, input.PeriodInterval, input.LockDate
            );

            return ObjectMapper.Map<FiscalYear, FiscalYearDto>(fiscalYear);
        }

        [Authorize(ERPAcc2Permissions.FiscalYears.Edit)]
        public virtual async Task<FiscalYearDto> UpdateAsync(Guid id, FiscalYearUpdateDto input)
        {

            var fiscalYear = await _fiscalYearManager.UpdateAsync(
            id,
            input.FiscalYearStatusId, input.FiscalYearName, input.StartDate, input.EndDate, input.CalanderYear, input.YearEndMonth, input.YearEndDay, input.IsCurrent, input.IsLocked, input.NoOfPeriods, input.PeriodInterval, input.LockDate, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<FiscalYear, FiscalYearDto>(fiscalYear);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(FiscalYearExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var fiscalYears = await _fiscalYearRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.FiscalYearName, input.StartDateMin, input.StartDateMax, input.EndDateMin, input.EndDateMax, input.LockDateMin, input.LockDateMax, input.CalanderYearMin, input.CalanderYearMax, input.YearEndMonthMin, input.YearEndMonthMax, input.YearEndDayMin, input.YearEndDayMax, input.IsCurrent, input.IsLocked, input.NoOfPeriodsMin, input.NoOfPeriodsMax, input.PeriodInterval);
            var items = fiscalYears.Select(item => new
            {
                FiscalYearName = item.FiscalYear.FiscalYearName,
                StartDate = item.FiscalYear.StartDate,
                EndDate = item.FiscalYear.EndDate,
                LockDate = item.FiscalYear.LockDate,
                CalanderYear = item.FiscalYear.CalanderYear,
                YearEndMonth = item.FiscalYear.YearEndMonth,
                YearEndDay = item.FiscalYear.YearEndDay,
                IsCurrent = item.FiscalYear.IsCurrent,
                IsLocked = item.FiscalYear.IsLocked,
                NoOfPeriods = item.FiscalYear.NoOfPeriods,
                PeriodInterval = item.FiscalYear.PeriodInterval,

                FiscalYearStatus = item.FiscalYearStatus?.Id,

            });

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(items);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "FiscalYears.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new FiscalYearExcelDownloadTokenCacheItem { Token = token },
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