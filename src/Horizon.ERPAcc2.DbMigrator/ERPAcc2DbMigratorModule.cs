using Horizon.ERPAcc2.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Horizon.ERPAcc2.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ERPAcc2EntityFrameworkCoreModule),
    typeof(ERPAcc2ApplicationContractsModule)
)]
public class ERPAcc2DbMigratorModule : AbpModule
{
}
