//-----------------------------------------------------------------------------
// <copyright file="Global.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using FEHub.Entity;

using Respawn;

namespace FEHub.Tests.Integration
{
    internal static class Global
    {
        public static string ConnectionString { get; set; }

        public static Func<FehContext> GetDbContext { get; set; }

        public static Task ResetDatabaseAsync()
        {
            var checkpoint = new Checkpoint();

            return checkpoint.Reset(ConnectionString);
        }
    }
}
