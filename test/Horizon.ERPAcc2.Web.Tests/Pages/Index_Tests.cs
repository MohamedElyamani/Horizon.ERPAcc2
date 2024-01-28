using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Horizon.ERPAcc2.Pages;

[Collection(ERPAcc2TestConsts.CollectionDefinitionName)]
public class Index_Tests : ERPAcc2WebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
