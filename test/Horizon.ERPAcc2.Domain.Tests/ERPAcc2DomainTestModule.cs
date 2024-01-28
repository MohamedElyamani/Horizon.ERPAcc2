using Volo.Abp.Modularity;

namespace Horizon.ERPAcc2;

[DependsOn(
    typeof(ERPAcc2DomainModule),
    typeof(ERPAcc2TestBaseModule)
)]
public class ERPAcc2DomainTestModule : AbpModule
{

}
