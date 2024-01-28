using Horizon.ERPAcc2.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Horizon.ERPAcc2.Permissions;

public class ERPAcc2PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ERPAcc2Permissions.GroupName);

        myGroup.AddPermission(ERPAcc2Permissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(ERPAcc2Permissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ERPAcc2Permissions.MyPermission1, L("Permission:MyPermission1"));

        var fiscalYearStatusPermission = myGroup.AddPermission(ERPAcc2Permissions.FiscalYearStatuses.Default, L("Permission:FiscalYearStatuses"));
        fiscalYearStatusPermission.AddChild(ERPAcc2Permissions.FiscalYearStatuses.Create, L("Permission:Create"));
        fiscalYearStatusPermission.AddChild(ERPAcc2Permissions.FiscalYearStatuses.Edit, L("Permission:Edit"));
        fiscalYearStatusPermission.AddChild(ERPAcc2Permissions.FiscalYearStatuses.Delete, L("Permission:Delete"));

        var fiscalYearPermission = myGroup.AddPermission(ERPAcc2Permissions.FiscalYears.Default, L("Permission:FiscalYears"));
        fiscalYearPermission.AddChild(ERPAcc2Permissions.FiscalYears.Create, L("Permission:Create"));
        fiscalYearPermission.AddChild(ERPAcc2Permissions.FiscalYears.Edit, L("Permission:Edit"));
        fiscalYearPermission.AddChild(ERPAcc2Permissions.FiscalYears.Delete, L("Permission:Delete"));

        var fiscalYearPeriodPermission = myGroup.AddPermission(ERPAcc2Permissions.FiscalYearPeriods.Default, L("Permission:FiscalYearPeriods"));
        fiscalYearPeriodPermission.AddChild(ERPAcc2Permissions.FiscalYearPeriods.Create, L("Permission:Create"));
        fiscalYearPeriodPermission.AddChild(ERPAcc2Permissions.FiscalYearPeriods.Edit, L("Permission:Edit"));
        fiscalYearPeriodPermission.AddChild(ERPAcc2Permissions.FiscalYearPeriods.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ERPAcc2Resource>(name);
    }
}