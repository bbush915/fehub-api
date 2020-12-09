//-----------------------------------------------------------------------------
// <copyright file="FehContextFactory.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FEHub.Entity
{
    public sealed class FehContextFactory : IDesignTimeDbContextFactory<FehContext>
    {
        public FehContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<FehContext>();
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-02BDJKR;Database=FEHub;Trusted_Connection=True");

            return new FehContext(dbContextOptionsBuilder.Options);
        }
    }
}
