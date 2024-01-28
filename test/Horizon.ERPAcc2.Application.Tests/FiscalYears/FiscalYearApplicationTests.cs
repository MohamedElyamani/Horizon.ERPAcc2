using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearsAppServiceTests<TStartupModule> : ERPAcc2ApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IFiscalYearsAppService _fiscalYearsAppService;
        private readonly IRepository<FiscalYear, Guid> _fiscalYearRepository;

        public FiscalYearsAppServiceTests()
        {
            _fiscalYearsAppService = GetRequiredService<IFiscalYearsAppService>();
            _fiscalYearRepository = GetRequiredService<IRepository<FiscalYear, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _fiscalYearsAppService.GetListAsync(new GetFiscalYearsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.FiscalYear.Id == Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850")).ShouldBe(true);
            result.Items.Any(x => x.FiscalYear.Id == Guid.Parse("195442f7-b130-4c64-9eee-011dcd2df034")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _fiscalYearsAppService.GetAsync(Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new FiscalYearCreateDto
            {
                FiscalYearName = "0479db1c14a244a8ba8c4d96a8053d9282b4bb0fc5c04a7aa7",
                StartDate = new DateTime(2010, 5, 25),
                EndDate = new DateTime(2000, 4, 2),
                LockDate = new DateTime(2005, 6, 11),
                CalanderYear = 1211539888,
                YearEndMonth = 7,
                YearEndDay = 53,
                IsCurrent = true,
                IsLocked = true,
                NoOfPeriods = 101,
                PeriodInterval = "bbbb2"
            };

            // Act
            var serviceResult = await _fiscalYearsAppService.CreateAsync(input);

            // Assert
            var result = await _fiscalYearRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.FiscalYearName.ShouldBe("0479db1c14a244a8ba8c4d96a8053d9282b4bb0fc5c04a7aa7");
            result.StartDate.ShouldBe(new DateTime(2010, 5, 25));
            result.EndDate.ShouldBe(new DateTime(2000, 4, 2));
            result.LockDate.ShouldBe(new DateTime(2005, 6, 11));
            result.CalanderYear.ShouldBe(1211539888);
            result.YearEndMonth.ShouldBe(7);
            result.YearEndDay.ShouldBe(53);
            result.IsCurrent.ShouldBe(true);
            result.IsLocked.ShouldBe(true);
            result.NoOfPeriods.ShouldBe(101);
            result.PeriodInterval.ShouldBe("bbbb2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new FiscalYearUpdateDto()
            {
                FiscalYearName = "7c0f053a199449efb29efcce13ea63b28fd51d4e9f7c45958f",
                StartDate = new DateTime(2019, 7, 16),
                EndDate = new DateTime(2018, 4, 18),
                LockDate = new DateTime(2001, 1, 9),
                CalanderYear = 1946854428,
                YearEndMonth = 112,
                YearEndDay = 95,
                IsCurrent = true,
                IsLocked = true,
                NoOfPeriods = 55,
                PeriodInterval = "656ac"
            };

            // Act
            var serviceResult = await _fiscalYearsAppService.UpdateAsync(Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850"), input);

            // Assert
            var result = await _fiscalYearRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.FiscalYearName.ShouldBe("7c0f053a199449efb29efcce13ea63b28fd51d4e9f7c45958f");
            result.StartDate.ShouldBe(new DateTime(2019, 7, 16));
            result.EndDate.ShouldBe(new DateTime(2018, 4, 18));
            result.LockDate.ShouldBe(new DateTime(2001, 1, 9));
            result.CalanderYear.ShouldBe(1946854428);
            result.YearEndMonth.ShouldBe(112);
            result.YearEndDay.ShouldBe(95);
            result.IsCurrent.ShouldBe(true);
            result.IsLocked.ShouldBe(true);
            result.NoOfPeriods.ShouldBe(55);
            result.PeriodInterval.ShouldBe("656ac");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _fiscalYearsAppService.DeleteAsync(Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850"));

            // Assert
            var result = await _fiscalYearRepository.FindAsync(c => c.Id == Guid.Parse("b35b1480-ae5c-4195-9112-68050cbfb850"));

            result.ShouldBeNull();
        }
    }
}