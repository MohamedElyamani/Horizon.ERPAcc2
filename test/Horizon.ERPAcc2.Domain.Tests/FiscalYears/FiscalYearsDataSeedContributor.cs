using Horizon.ERPAcc2.FiscalYearStatuses;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Horizon.ERPAcc2.FiscalYears;

namespace Horizon.ERPAcc2.FiscalYears
{
    public class FiscalYearsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly FiscalYearStatusesDataSeedContributor _fiscalYearStatusesDataSeedContributor;

        public FiscalYearsDataSeedContributor(IFiscalYearRepository fiscalYearRepository, IUnitOfWorkManager unitOfWorkManager, FiscalYearStatusesDataSeedContributor fiscalYearStatusesDataSeedContributor)
        {
            _fiscalYearRepository = fiscalYearRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _fiscalYearStatusesDataSeedContributor = fiscalYearStatusesDataSeedContributor;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _fiscalYearStatusesDataSeedContributor.SeedAsync(context);

            await _fiscalYearRepository.InsertAsync(new FiscalYear
            (
                id: Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850"),
                fiscalYearName: "358b682166dd46089a9de7277f3f61d4228ece1347a54cc881",
                startDate: new DateTime(2006, 2, 18),
                endDate: new DateTime(2011, 9, 12),
                lockDate: new DateTime(2006, 2, 8),
                calanderYear: 20134454,
                yearEndMonth: 70,
                yearEndDay: 20,
                isCurrent: true,
                isLocked: true,
                noOfPeriods: 70,
                periodInterval: "ac4bf",
                fiscalYearStatusId: null
            ));

            await _fiscalYearRepository.InsertAsync(new FiscalYear
            (
                id: Guid.Parse("195442f7-b130-4c64-9eee-011dcd2df034"),
                fiscalYearName: "603cd79ca6ae49ae8b747af0a7b7729bfee2a7df2fdd47c1ab",
                startDate: new DateTime(2012, 11, 10),
                endDate: new DateTime(2018, 1, 8),
                lockDate: new DateTime(2009, 9, 27),
                calanderYear: 1778198715,
                yearEndMonth: 31,
                yearEndDay: 92,
                isCurrent: true,
                isLocked: true,
                noOfPeriods: 77,
                periodInterval: "2d252",
                fiscalYearStatusId: null
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}