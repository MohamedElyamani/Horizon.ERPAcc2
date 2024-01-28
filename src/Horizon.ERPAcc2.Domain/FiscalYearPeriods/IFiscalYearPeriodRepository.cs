using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public partial interface IFiscalYearPeriodRepository : IRepository<FiscalYearPeriod, Guid>
    {
        Task<List<FiscalYearPeriod>> GetListByFiscalYearIdAsync(
    Guid fiscalYearId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default
);

        Task<long> GetCountByFiscalYearIdAsync(Guid fiscalYearId, CancellationToken cancellationToken = default);

        Task<List<FiscalYearPeriod>> GetListAsync(
                    string? filterText = null,
                    string? periodName = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    DateTime? startDateMin = null,
                    DateTime? startDateMax = null,
                    DateTime? endDateMin = null,
                    DateTime? endDateMax = null,
                    int? periodStatusIdMin = null,
                    int? periodStatusIdMax = null,
                    bool? isClosed = null,
                    DateTime? closeDateMin = null,
                    DateTime? closeDateMax = null,
                    decimal? totalDepitMin = null,
                    decimal? totalDepitMax = null,
                    decimal? totalCreditMin = null,
                    decimal? totalCreditMax = null,
                    decimal? closingBalanceMin = null,
                    decimal? closingBalanceMax = null,
                    decimal? beginingInventoryMin = null,
                    decimal? beginingInventoryMax = null,
                    decimal? purchasesMin = null,
                    decimal? purchasesMax = null,
                    decimal? endiningInventoryMin = null,
                    decimal? endiningInventoryMax = null,
                    decimal? cOGSMin = null,
                    decimal? cOGSMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? periodName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            int? periodStatusIdMin = null,
            int? periodStatusIdMax = null,
            bool? isClosed = null,
            DateTime? closeDateMin = null,
            DateTime? closeDateMax = null,
            decimal? totalDepitMin = null,
            decimal? totalDepitMax = null,
            decimal? totalCreditMin = null,
            decimal? totalCreditMax = null,
            decimal? closingBalanceMin = null,
            decimal? closingBalanceMax = null,
            decimal? beginingInventoryMin = null,
            decimal? beginingInventoryMax = null,
            decimal? purchasesMin = null,
            decimal? purchasesMax = null,
            decimal? endiningInventoryMin = null,
            decimal? endiningInventoryMax = null,
            decimal? cOGSMin = null,
            decimal? cOGSMax = null,
            CancellationToken cancellationToken = default);
    }
}