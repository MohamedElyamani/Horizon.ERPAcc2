using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Horizon.ERPAcc2.Localization;
using Horizon.ERPAcc2.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.OpenIddict.Pro.Web.Menus;
using Volo.Abp.UI.Navigation;
using Volo.Saas.Host.Navigation;

namespace Horizon.ERPAcc2.Web.Menus;

public class ERPAcc2MenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ERPAcc2Resource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ERPAcc2Menus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        //HostDashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ERPAcc2Menus.HostDashboard,
                l["Menu:Dashboard"],
                "~/HostDashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(ERPAcc2Permissions.Dashboard.Host)
        );

        //TenantDashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ERPAcc2Menus.TenantDashboard,
                l["Menu:Dashboard"],
                "~/Dashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(ERPAcc2Permissions.Dashboard.Tenant)
        );

        context.Menu.SetSubItemOrder(SaasHostMenuNames.GroupName, 3);

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration->OpenIddict
        administration.SetSubItemOrder(OpenIddictProMenus.GroupName, 2);

        //Administration->Language Management
        administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 3);

        //Administration->Text Template Management
        administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 4);

        //Administration->Audit Logs
        administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 5);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                ERPAcc2Menus.FiscalYearStatuses,
                l["Menu:FiscalYearStatuses"],
                url: "/FiscalYearStatuses",
                icon: "fa fa-file",
                requiredPermissionName: ERPAcc2Permissions.FiscalYearStatuses.Default)
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                ERPAcc2Menus.FiscalYears,
                l["Menu:FiscalYears"],
                url: "/FiscalYears",
                icon: "fa fa-book",
                requiredPermissionName: ERPAcc2Permissions.FiscalYears.Default)
        );
        return Task.CompletedTask;
    }
}