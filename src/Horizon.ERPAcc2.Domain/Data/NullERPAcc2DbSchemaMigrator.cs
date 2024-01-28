using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Horizon.ERPAcc2.Data;

/* This is used if database provider does't define
 * IERPAcc2DbSchemaMigrator implementation.
 */
public class NullERPAcc2DbSchemaMigrator : IERPAcc2DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
