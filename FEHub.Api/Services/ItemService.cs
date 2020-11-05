//-----------------------------------------------------------------------------
// <copyright file="ItemService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    public sealed class ItemService : IItemService
    {
        private readonly FehContext _dbContext;

        public ItemService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<List<Item>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return this._dbContext
                .Items
                .ToListAsync(cancellationToken);
        }

        public Task<Item> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return this._dbContext
                .Items
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
