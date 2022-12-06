using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Respawn;

namespace FEHub.Tests.Integration;

[TestClass]
public abstract class ResettingDatabaseTests
{
    private static Respawner _respawner;

    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static async Task InitializeRespawner(TestContext _)
    {
        // NOTE - By default, Respawn is configured to reset everything in the DB.
        // c.f. https://github.com/jbogard/Respawn for more information.

        _respawner = await Globals.CreateRespawnerAsync(new RespawnerOptions());
    }

    [TestCleanup]
    public async Task ResetDatabase()
    {
        if (_respawner is null)
        {
            return;
        }

        // NOTE - Reset any changes made by the test.

        await _respawner.ResetAsync(Globals.ConnectionString);
    }
}
