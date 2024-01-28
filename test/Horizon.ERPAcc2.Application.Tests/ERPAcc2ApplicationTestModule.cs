using Volo.Abp.Modularity;

namespace Horizon.ERPAcc2;

[DependsOn(
    typeof(ERPAcc2ApplicationModule),
    typeof(ERPAcc2DomainTestModule)
)]
public class ERPAcc2ApplicationTestModule : AbpModule
{

}
