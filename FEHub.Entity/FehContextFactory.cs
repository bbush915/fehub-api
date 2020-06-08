//-----------------------------------------------------------------------------
// <copyright file="FehContextFactory.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FEHub.Entity
{
    public class FehContextFactory : IDesignTimeDbContextFactory<FehContext>
    {
        #region Fields
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["FEHub"]?.ConnectionString 
            //?? "Data Source=localhost;Initial Catalog=FEHub;Integrated Security=true";
            ?? @"Data Source=C:\Source\FEHub\fehub\fehub-api\FEHub.sqlite3;";
        #endregion

        #region Methods
        public FehContext CreateDbContext()
        {
            return this.CreateDbContext(null);
        }

        public FehContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder
                //.UseSqlServer(_connectionString);
                .UseSqlite(_connectionString);

            return new FehContext(optionsBuilder.Options);
        }
        #endregion
    }
}
