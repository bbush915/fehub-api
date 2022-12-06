using System.Threading.Tasks;

using FEHub.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Dac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Respawn;

namespace FEHub.Tests.Integration;

[TestClass]
public sealed class Setup
{
    [AssemblyInitialize]
    public static void BeforeAllAsync(TestContext _)
    {
        // NOTE - Load configuration.

        var configurationBuilder = new ConfigurationBuilder();
        var configuration = configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

        // NOTE - Set up globals.

        Globals.ConnectionString = configuration.GetConnectionString("FEHub");

        var dbContextOptionsBuilder = new DbContextOptionsBuilder();
        var dbContextOptions = dbContextOptionsBuilder.UseSqlServer(Globals.ConnectionString).Options;

        Globals.CreateContext = () => new FehContext(dbContextOptions);

        Globals.CreateRespawnerAsync = (options) => Respawner.CreateAsync(Globals.ConnectionString, options);

        // NOTE - Create test database.

        var dacServices = new DacServices(Globals.ConnectionString);

        var dacpacPath = configuration.GetValue<string>("DACPAC");
        using var dacPackage = DacPackage.Load(dacpacPath);

        dacServices.Deploy(dacPackage, "FEHub.Test", upgradeExisting: true);
    }

    [AssemblyCleanup]
    public async static Task AfterAllAsync()
    {
        // NOTE - Delete database.

        using var dbContext = Globals.CreateContext();

        await dbContext.Database.EnsureDeletedAsync();
    }
}
