using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class FiscalYearStatusManagerBase : DomainService
    {
        protected IFiscalYearStatusRepository _fiscalYearStatusRepository;

        public FiscalYearStatusManagerBase(IFiscalYearStatusRepository fiscalYearStatusRepository)
        {
            _fiscalYearStatusRepository = fiscalYearStatusRepository;
        }

        public virtual async Task<FiscalYearStatus> CreateAsync(
        string fiscalYearStatusTitle)
        {
            Check.NotNullOrWhiteSpace(fiscalYearStatusTitle, nameof(fiscalYearStatusTitle));
            Check.Length(fiscalYearStatusTitle, nameof(fiscalYearStatusTitle), FiscalYearStatusConsts.FiscalYearStatusTitleMaxLength);

            var fiscalYearStatus = new FiscalYearStatus(

             fiscalYearStatusTitle
             );

            return await _fiscalYearStatusRepository.InsertAsync(fiscalYearStatus);
        }

        public virtual async Task<FiscalYearStatus> UpdateAsync(
            int id,
            string fiscalYearStatusTitle, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(fiscalYearStatusTitle, nameof(fiscalYearStatusTitle));
            Check.Length(fiscalYearStatusTitle, nameof(fiscalYearStatusTitle), FiscalYearStatusConsts.FiscalYearStatusTitleMaxLength);

            var fiscalYearStatus = await _fiscalYearStatusRepository.GetAsync(id);

            fiscalYearStatus.FiscalYearStatusTitle = fiscalYearStatusTitle;

            fiscalYearStatus.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _fiscalYearStatusRepository.UpdateAsync(fiscalYearStatus);
        }

    }
}