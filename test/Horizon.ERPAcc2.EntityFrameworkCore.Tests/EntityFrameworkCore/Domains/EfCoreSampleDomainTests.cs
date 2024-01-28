using Horizon.ERPAcc2.Samples;
using Xunit;

namespace Horizon.ERPAcc2.EntityFrameworkCore.Domains;

[Collection(ERPAcc2TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ERPAcc2EntityFrameworkCoreTestModule>
{

}
