using Horizon.ERPAcc2.FiscalYearPeriods;
using Horizon.ERPAcc2.FiscalYears;

using Horizon.ERPAcc2.FiscalYearStatuses;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;

namespace Horizon.ERPAcc2.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class ERPAcc2DbContext :
    AbpDbContext<ERPAcc2DbContext>,
    IIdentityProDbContext,
    ISaasDbContext
{
    public DbSet<FiscalYearPeriod> FiscalYearPeriods { get; set; } = null!;
    public DbSet<FiscalYear> FiscalYears { get; set; } = null!;
    public DbSet<FiscalYearStatus> FiscalYearStatuses { get; set; } = null!;
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public ERPAcc2DbContext(DbContextOptions<ERPAcc2DbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureFeatureManagement();
        builder.ConfigureLanguageManagement();
        builder.ConfigureSaas();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureGdpr();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ERPAcc2Consts.DbTablePrefix + "YourEntities", ERPAcc2Consts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        if (builder.IsHostDatabase())
        {
            builder.Entity<FiscalYearStatus>(b =>
{
    b.ToTable(ERPAcc2Consts.DbTablePrefix + "FiscalYearStatus", ERPAcc2Consts.DbSchema);
    b.ConfigureByConvention();
    b.Property(x => x.FiscalYearStatusTitle).HasColumnName(nameof(FiscalYearStatus.FiscalYearStatusTitle)).IsRequired().HasMaxLength(FiscalYearStatusConsts.FiscalYearStatusTitleMaxLength);
});

        }
        if (builder.IsHostDatabase())
        {

        }

        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<FiscalYear>(b =>
{
    b.ToTable(ERPAcc2Consts.DbTablePrefix + "FiscalYear", ERPAcc2Consts.DbSchema);
    b.ConfigureByConvention();
    b.Property(x => x.FiscalYearName).HasColumnName(nameof(FiscalYear.FiscalYearName)).IsRequired().HasMaxLength(FiscalYearConsts.FiscalYearNameMaxLength);
    b.Property(x => x.StartDate).HasColumnName(nameof(FiscalYear.StartDate)).IsRequired();
    b.Property(x => x.EndDate).HasColumnName(nameof(FiscalYear.EndDate)).IsRequired();
    b.Property(x => x.LockDate).HasColumnName(nameof(FiscalYear.LockDate));
    b.Property(x => x.CalanderYear).HasColumnName(nameof(FiscalYear.CalanderYear)).IsRequired();
    b.Property(x => x.YearEndMonth).HasColumnName(nameof(FiscalYear.YearEndMonth)).IsRequired();
    b.Property(x => x.YearEndDay).HasColumnName(nameof(FiscalYear.YearEndDay)).IsRequired();
    b.Property(x => x.IsCurrent).HasColumnName(nameof(FiscalYear.IsCurrent)).IsRequired();
    b.Property(x => x.IsLocked).HasColumnName(nameof(FiscalYear.IsLocked)).IsRequired();
    b.Property(x => x.NoOfPeriods).HasColumnName(nameof(FiscalYear.NoOfPeriods)).IsRequired();
    b.Property(x => x.PeriodInterval).HasColumnName(nameof(FiscalYear.PeriodInterval)).IsRequired().HasMaxLength(FiscalYearConsts.PeriodIntervalMaxLength);
    b.HasOne<FiscalYearStatus>().WithMany().HasForeignKey(x => x.FiscalYearStatusId).OnDelete(DeleteBehavior.NoAction);
    b.HasMany(x => x.FiscalYearPeriods).WithOne().HasForeignKey(x => x.FiscalYearId).IsRequired().OnDelete(DeleteBehavior.NoAction);
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<FiscalYearPeriod>(b =>
{
    b.ToTable(ERPAcc2Consts.DbTablePrefix + "FiscalYearPeriod", ERPAcc2Consts.DbSchema);
    b.ConfigureByConvention();
    b.Property(x => x.PeriodName).HasColumnName(nameof(FiscalYearPeriod.PeriodName)).IsRequired().HasMaxLength(FiscalYearPeriodConsts.PeriodNameMaxLength);
    b.Property(x => x.CompanyId).HasColumnName(nameof(FiscalYearPeriod.CompanyId)).IsRequired();
    b.Property(x => x.StartDate).HasColumnName(nameof(FiscalYearPeriod.StartDate)).IsRequired();
    b.Property(x => x.EndDate).HasColumnName(nameof(FiscalYearPeriod.EndDate)).IsRequired();
    b.Property(x => x.PeriodStatusId).HasColumnName(nameof(FiscalYearPeriod.PeriodStatusId)).IsRequired();
    b.Property(x => x.IsClosed).HasColumnName(nameof(FiscalYearPeriod.IsClosed)).IsRequired();
    b.Property(x => x.CloseDate).HasColumnName(nameof(FiscalYearPeriod.CloseDate));
    b.Property(x => x.TotalDepit).HasColumnName(nameof(FiscalYearPeriod.TotalDepit)).IsRequired();
    b.Property(x => x.TotalCredit).HasColumnName(nameof(FiscalYearPeriod.TotalCredit)).IsRequired();
    b.Property(x => x.ClosingBalance).HasColumnName(nameof(FiscalYearPeriod.ClosingBalance)).IsRequired();
    b.Property(x => x.BeginingInventory).HasColumnName(nameof(FiscalYearPeriod.BeginingInventory)).IsRequired();
    b.Property(x => x.Purchases).HasColumnName(nameof(FiscalYearPeriod.Purchases)).IsRequired();
    b.Property(x => x.EndiningInventory).HasColumnName(nameof(FiscalYearPeriod.EndiningInventory)).IsRequired();
    b.Property(x => x.COGS).HasColumnName(nameof(FiscalYearPeriod.COGS)).IsRequired();
    b.HasOne<FiscalYear>().WithMany(x => x.FiscalYearPeriods).HasForeignKey(x => x.FiscalYearId).IsRequired().OnDelete(DeleteBehavior.NoAction);
});

        }
    }
}