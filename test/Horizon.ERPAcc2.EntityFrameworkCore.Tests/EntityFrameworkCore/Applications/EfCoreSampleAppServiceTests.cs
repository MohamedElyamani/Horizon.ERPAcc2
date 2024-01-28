using Horizon.ERPAcc2.Samples;
using Xunit;

namespace Horizon.ERPAcc2.EntityFrameworkCore.Applications;

[Collection(ERPAcc2TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ERPAcc2EntityFrameworkCoreTestModule>
{

}
