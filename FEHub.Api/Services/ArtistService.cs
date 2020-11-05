//-----------------------------------------------------------------------------
// <copyright file="ArtistService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    public sealed class ArtistService : IArtistService
    {
        private readonly FehContext _dbContext;

        public ArtistService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<List<Artist>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return this._dbContext
                .Artists
                .ToListAsync(cancellationToken);
        }

        public async Task<IDictionary<int, Artist>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        {
            return await this._dbContext
                .Artists
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(k => k.Id, v => v, cancellationToken);
        }

        public Task<Artist> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return this._dbContext
                .Artists
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
