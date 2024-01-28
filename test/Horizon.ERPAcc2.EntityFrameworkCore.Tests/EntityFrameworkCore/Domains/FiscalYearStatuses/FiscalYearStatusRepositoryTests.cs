using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Horizon.ERPAcc2.FiscalYearStatuses;
using Horizon.ERPAcc2.EntityFrameworkCore;
using Xunit;

namespace Horizon.ERPAcc2.EntityFrameworkCore.Domains.FiscalYearStatuses
{
    public class FiscalYearStatusRepositoryTests : ERPAcc2EntityFrameworkCoreTestBase
    {
        private readonly IFiscalYearStatusRepository _fiscalYearStatusRepository;

        public FiscalYearStatusRepositoryTests()
        {
            _fiscalYearStatusRepository = GetRequiredService<IFiscalYearStatusRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _fiscalYearStatusRepository.GetListAsync(
                    fiscalYearStatusTitle: "9d5f47b92c1d48a8aa1d94df7304923c5adea29430ac4a98b4"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(1);
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _fiscalYearStatusRepository.GetCountAsync(
                    fiscalYearStatusTitle: "0a91b86032474735a938f47bf4a6b3796e3a19daef57404390"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}