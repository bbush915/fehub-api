using System;
using System.Threading.Tasks;

using FEHub.Entity;

using Respawn;

namespace FEHub.Tests.Integration;

internal static class Globals
{
    public static string ConnectionString { get; set; }

    public static Func<FehContext> CreateContext { get; set; }

    public static Func<RespawnerOptions, Task<Respawner>> CreateRespawnerAsync { get; set; }
}
