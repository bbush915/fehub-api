﻿//-----------------------------------------------------------------------------
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
        private static string _connectionString;
        #endregion

        #region Properties
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    return @"Data Source=C:\Source\FEHub\fehub\fehub-api\FEHub.sqlite3;";
                }

                return _connectionString;
            }

            set
            {
                _connectionString = value;
            }
        }
        #endregion

        #region Methods
        public FehContext CreateDbContext()
        {
            return this.CreateDbContext(null);
        }

        public FehContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlite(ConnectionString);

            return new FehContext(optionsBuilder.Options);
        }
        #endregion
    }
}
