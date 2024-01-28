using System.Threading.Tasks;

namespace Horizon.ERPAcc2.Data;

public interface IERPAcc2DbSchemaMigrator
{
    Task MigrateAsync();
}
