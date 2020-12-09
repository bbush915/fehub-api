//-----------------------------------------------------------------------------
// <copyright file="TestHelpers.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Api;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace FEHub.Tests.Integration.Utilities
{
    internal static class TestHelpers
    {
        public static TestServer GetTestServer()
        {
            return new TestServer(
                new WebHostBuilder()
                    .ConfigureAppConfiguration(
                        (_, configurationBuilder) =>
                            configurationBuilder.AddJsonFile("appsettings.json")
                    )
                    .UseStartup<Startup>()
            );
        }
    }
}
