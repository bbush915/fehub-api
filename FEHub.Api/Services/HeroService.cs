//-----------------------------------------------------------------------------
// <copyright file="HeroService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    internal sealed class HeroService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public HeroService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<Hero>> GetAllAsync()
        {
            return await this._dbContext
                .Heroes
                .ToListAsync();
        }

        public async Task<Hero> GetByIdAsync(Guid id)
        {
            return await this._dbContext
                .Heroes
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
