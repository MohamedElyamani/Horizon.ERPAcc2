using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Horizon.ERPAcc2.Web;

[Dependency(ReplaceServices = true)]
public class ERPAcc2BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ERPAcc2";
}
