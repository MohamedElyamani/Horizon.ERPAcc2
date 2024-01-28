using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Horizon.ERPAcc2.FiscalYears;
using Horizon.ERPAcc2.EntityFrameworkCore;
using Xunit;

namespace Horizon.ERPAcc2.EntityFrameworkCore.Domains.FiscalYears
{
    public class FiscalYearRepositoryTests : ERPAcc2EntityFrameworkCoreTestBase
    {
        private readonly IFiscalYearRepository _fiscalYearRepository;

        public FiscalYearRepositoryTests()
        {
            _fiscalYearRepository = GetRequiredService<IFiscalYearRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _fiscalYearRepository.GetListAsync(
                    fiscalYearName: "358b682166dd46089a9de7277f3f61d4228ece1347a54cc881",
                    isCurrent: true,
                    isLocked: true,
                    periodInterval: "ac4bf"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _fiscalYearRepository.GetCountAsync(
                    fiscalYearName: "603cd79ca6ae49ae8b747af0a7b7729bfee2a7df2fdd47c1ab",
                    isCurrent: true,
                    isLocked: true,
                    periodInterval: "2d252"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}