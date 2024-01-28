using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Horizon.ERPAcc2.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ERPAcc2DbContextFactory : IDesignTimeDbContextFactory<ERPAcc2DbContext>
{
    public ERPAcc2DbContext CreateDbContext(string[] args)
    {
        ERPAcc2EfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ERPAcc2DbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ERPAcc2DbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Horizon.ERPAcc2.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
