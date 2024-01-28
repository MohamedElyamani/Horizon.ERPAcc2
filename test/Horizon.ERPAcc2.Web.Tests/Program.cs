using Microsoft.AspNetCore.Builder;
using Horizon.ERPAcc2;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<ERPAcc2WebTestModule>();

public partial class Program
{
}
