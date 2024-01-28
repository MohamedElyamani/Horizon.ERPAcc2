using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public partial interface IFiscalYearStatusRepository : IRepository<FiscalYearStatus, int>
    {
        Task<List<FiscalYearStatus>> GetListAsync(
            string? filterText = null,
            string? fiscalYearStatusTitle = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? fiscalYearStatusTitle = null,
            CancellationToken cancellationToken = default);
    }
}