//-----------------------------------------------------------------------------
// <copyright file="AccessoryService.cs">
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
    internal sealed class AccessoryService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public AccessoryService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<Accessory>> GetAllAsync()
        {
            return await this._dbContext
                .Accessories
                .ToListAsync();
        }

        public async Task<Accessory> GetByIdAsync(Guid id)
        {
            return await this._dbContext
                .Accessories
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
