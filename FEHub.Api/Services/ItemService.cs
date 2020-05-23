//-----------------------------------------------------------------------------
// <copyright file="ItemService.cs">
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
    internal sealed class ItemService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public ItemService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<Item>> GetAllAsync()
        {
            return await this._dbContext
                .Items
                .ToListAsync();
        }

        public async Task<Item> GetByIdAsync(Guid id)
        {
            return await this._dbContext
                .Items
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
