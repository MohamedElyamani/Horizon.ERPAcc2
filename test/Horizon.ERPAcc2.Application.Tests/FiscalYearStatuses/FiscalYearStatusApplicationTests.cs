using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class FiscalYearStatusesAppServiceTests<TStartupModule> : ERPAcc2ApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IFiscalYearStatusesAppService _fiscalYearStatusesAppService;
        private readonly IRepository<FiscalYearStatus, int> _fiscalYearStatusRepository;

        public FiscalYearStatusesAppServiceTests()
        {
            _fiscalYearStatusesAppService = GetRequiredService<IFiscalYearStatusesAppService>();
            _fiscalYearStatusRepository = GetRequiredService<IRepository<FiscalYearStatus, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _fiscalYearStatusesAppService.GetListAsync(new GetFiscalYearStatusesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _fiscalYearStatusesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new FiscalYearStatusCreateDto
            {
                FiscalYearStatusTitle = "01223149dde547a2af5ec5db7d773d541ce467e7838a4c42b0"
            };

            // Act
            var serviceResult = await _fiscalYearStatusesAppService.CreateAsync(input);

            // Assert
            var result = await _fiscalYearStatusRepository.FindAsync(c => c.FiscalYearStatusTitle == serviceResult.FiscalYearStatusTitle);

            result.ShouldNotBe(null);
            result.FiscalYearStatusTitle.ShouldBe("01223149dde547a2af5ec5db7d773d541ce467e7838a4c42b0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new FiscalYearStatusUpdateDto()
            {
                FiscalYearStatusTitle = "ecb450379faa461996e1a3c78d0c20104d088a33c9d04a7897"
            };

            // Act
            var serviceResult = await _fiscalYearStatusesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _fiscalYearStatusRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.FiscalYearStatusTitle.ShouldBe("ecb450379faa461996e1a3c78d0c20104d088a33c9d04a7897");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _fiscalYearStatusesAppService.DeleteAsync(1);

            // Assert
            var result = await _fiscalYearStatusRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}