namespace Horizon.ERPAcc2.FiscalYears
{
    public static class FiscalYearConsts
    {
        private const string DefaultSorting = "{0}FiscalYearName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "FiscalYear." : string.Empty);
        }

        public const int FiscalYearNameMaxLength = 50;
        public const int PeriodIntervalMaxLength = 5;
    }
}