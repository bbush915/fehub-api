//-----------------------------------------------------------------------------
// <copyright file="Program.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FEHub.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    (webHostBuilder) =>
                    {
                        webHostBuilder
                            .UseKestrel()
                            .UseStartup<Startup>();
                    }
                );
    }
}
