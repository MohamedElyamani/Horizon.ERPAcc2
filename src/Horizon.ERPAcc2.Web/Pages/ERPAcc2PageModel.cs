using Horizon.ERPAcc2.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Horizon.ERPAcc2.Web.Pages;

public abstract class ERPAcc2PageModel : AbpPageModel
{
    protected ERPAcc2PageModel()
    {
        LocalizationResourceType = typeof(ERPAcc2Resource);
    }
}
