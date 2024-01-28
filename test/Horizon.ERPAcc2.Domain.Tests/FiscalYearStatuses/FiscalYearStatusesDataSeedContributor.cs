using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Horizon.ERPAcc2.FiscalYearStatuses;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public class FiscalYearStatusesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IFiscalYearStatusRepository _fiscalYearStatusRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public FiscalYearStatusesDataSeedContributor(IFiscalYearStatusRepository fiscalYearStatusRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _fiscalYearStatusRepository = fiscalYearStatusRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _fiscalYearStatusRepository.InsertAsync(new FiscalYearStatus
            (
                fiscalYearStatusTitle: "9d5f47b92c1d48a8aa1d94df7304923c5adea29430ac4a98b4"
            ));

            await _fiscalYearStatusRepository.InsertAsync(new FiscalYearStatus
            (
                fiscalYearStatusTitle: "0a91b86032474735a938f47bf4a6b3796e3a19daef57404390"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}