using Horizon.ERPAcc2.Localization;
using Volo.Abp.Application.Services;

namespace Horizon.ERPAcc2;

/* Inherit your application services from this class.
 */
public abstract class ERPAcc2AppService : ApplicationService
{
    protected ERPAcc2AppService()
    {
        LocalizationResource = typeof(ERPAcc2Resource);
    }
}
