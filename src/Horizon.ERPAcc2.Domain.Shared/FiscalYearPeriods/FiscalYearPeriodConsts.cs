namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public static class FiscalYearPeriodConsts
    {
        private const string DefaultSorting = "{0}PeriodName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "FiscalYearPeriod." : string.Empty);
        }

        public const int PeriodNameMaxLength = 150;
    }
}