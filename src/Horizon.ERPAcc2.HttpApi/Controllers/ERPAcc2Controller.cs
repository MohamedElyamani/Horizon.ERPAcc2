using Horizon.ERPAcc2.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Horizon.ERPAcc2.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ERPAcc2Controller : AbpControllerBase
{
    protected ERPAcc2Controller()
    {
        LocalizationResource = typeof(ERPAcc2Resource);
    }
}
