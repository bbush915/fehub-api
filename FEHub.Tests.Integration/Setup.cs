//-----------------------------------------------------------------------------
// <copyright file="Setup.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Threading.Tasks;

using FEHub.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Dac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration
{
    [TestClass]
    public sealed class Setup
    {
        [AssemblyInitialize]
        public static void BeforeAllAsync(TestContext _)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var configuration = configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            Global.ConnectionString = configuration.GetConnectionString("FEHub");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            var dbContextOptions = dbContextOptionsBuilder.UseSqlServer(Global.ConnectionString).Options;

            Global.GetDbContext = () => new FehContext(dbContextOptions);

            var dacServices = new DacServices(Global.ConnectionString);

            var dacpacPath = configuration.GetValue<string>("DACPAC");
            using var dacPackage = DacPackage.Load(dacpacPath);

            dacServices.Deploy(dacPackage, "FEHub.Test", upgradeExisting: true);
        }

        [AssemblyCleanup]
        public async static Task AfterAllAsync()
        {
            using var dbContext = Global.GetDbContext();

            await dbContext.Database.EnsureDeletedAsync();
        }
    }
}
