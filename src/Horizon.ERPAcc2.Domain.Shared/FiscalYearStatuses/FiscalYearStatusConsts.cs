namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public static class FiscalYearStatusConsts
    {
        private const string DefaultSorting = "{0}FiscalYearStatusTitle asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "FiscalYearStatus." : string.Empty);
        }

        public const int FiscalYearStatusTitleMaxLength = 50;
    }
}