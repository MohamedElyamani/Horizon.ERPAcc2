namespace Horizon.ERPAcc2.Permissions;

public static class ERPAcc2Permissions
{
    public const string GroupName = "ERPAcc2";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = DashboardGroup + ".Tenant";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class FiscalYearStatuses
    {
        public const string Default = GroupName + ".FiscalYearStatuses";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class FiscalYears
    {
        public const string Default = GroupName + ".FiscalYears";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class FiscalYearPeriods
    {
        public const string Default = GroupName + ".FiscalYearPeriods";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}