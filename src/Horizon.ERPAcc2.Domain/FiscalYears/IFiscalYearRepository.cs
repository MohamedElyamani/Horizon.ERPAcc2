using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Horizon.ERPAcc2.FiscalYears
{
    public partial interface IFiscalYearRepository : IRepository<FiscalYear, Guid>
    {
        Task<FiscalYearWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<FiscalYearWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? fiscalYearName = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            DateTime? lockDateMin = null,
            DateTime? lockDateMax = null,
            int? calanderYearMin = null,
            int? calanderYearMax = null,
            byte? yearEndMonthMin = null,
            byte? yearEndMonthMax = null,
            byte? yearEndDayMin = null,
            byte? yearEndDayMax = null,
            bool? isCurrent = null,
            bool? isLocked = null,
            byte? noOfPeriodsMin = null,
            byte? noOfPeriodsMax = null,
            string? periodInterval = null,
            int? fiscalYearStatusId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<FiscalYear>> GetListAsync(
                    string? filterText = null,
                    string? fiscalYearName = null,
                    DateTime? startDateMin = null,
                    DateTime? startDateMax = null,
                    DateTime? endDateMin = null,
                    DateTime? endDateMax = null,
                    DateTime? lockDateMin = null,
                    DateTime? lockDateMax = null,
                    int? calanderYearMin = null,
                    int? calanderYearMax = null,
                    byte? yearEndMonthMin = null,
                    byte? yearEndMonthMax = null,
                    byte? yearEndDayMin = null,
                    byte? yearEndDayMax = null,
                    bool? isCurrent = null,
                    bool? isLocked = null,
                    byte? noOfPeriodsMin = null,
                    byte? noOfPeriodsMax = null,
                    string? periodInterval = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? fiscalYearName = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            DateTime? lockDateMin = null,
            DateTime? lockDateMax = null,
            int? calanderYearMin = null,
            int? calanderYearMax = null,
            byte? yearEndMonthMin = null,
            byte? yearEndMonthMax = null,
            byte? yearEndDayMin = null,
            byte? yearEndDayMax = null,
            bool? isCurrent = null,
            bool? isLocked = null,
            byte? noOfPeriodsMin = null,
            byte? noOfPeriodsMax = null,
            string? periodInterval = null,
            int? fiscalYearStatusId = null,
            CancellationToken cancellationToken = default);
    }
}