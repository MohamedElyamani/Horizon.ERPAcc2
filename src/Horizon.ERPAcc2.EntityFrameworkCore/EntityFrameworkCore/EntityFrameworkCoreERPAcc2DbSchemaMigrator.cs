using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Horizon.ERPAcc2.Data;
using Volo.Abp.DependencyInjection;

namespace Horizon.ERPAcc2.EntityFrameworkCore;

public class EntityFrameworkCoreERPAcc2DbSchemaMigrator
    : IERPAcc2DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreERPAcc2DbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ERPAcc2DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ERPAcc2DbContext>()
            .Database
            .MigrateAsync();
    }
}
