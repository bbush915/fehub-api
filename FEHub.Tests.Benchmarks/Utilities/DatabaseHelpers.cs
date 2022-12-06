using System;
using FEHub.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FEHub.Tests.Benchmarks.Utilities;

internal static class DatabaseHelpers
{
    public static string ConnectionString { get; private set; }

    public static Func<FehContext> GetDbContext { get; private set;  }

    public static void Initialize()
    {
        var configurationBuilder = new ConfigurationBuilder();
        var configuration = configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

        ConnectionString = configuration.GetConnectionString("FEHub");

        var dbContextOptionsBuilder = new DbContextOptionsBuilder();
        var dbContextOptions = dbContextOptionsBuilder.UseSqlServer(ConnectionString).Options;

        GetDbContext = () => new FehContext(dbContextOptions);
    }
}
