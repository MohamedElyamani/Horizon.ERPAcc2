using Volo.Abp.Modularity;

namespace Horizon.ERPAcc2;

/* Inherit from this class for your domain layer tests. */
public abstract class ERPAcc2DomainTestBase<TStartupModule> : ERPAcc2TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
