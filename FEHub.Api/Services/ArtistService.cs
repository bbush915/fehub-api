//-----------------------------------------------------------------------------
// <copyright file="ArtistService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    internal sealed class ArtistService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public ArtistService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<Artist>> GetAllAsync()
        {
            return await this._dbContext
                .Artists
                .ToListAsync();
        }

        public async Task<IDictionary<int, Artist>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            return await this._dbContext
                .Artists
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(
                    x => x.Id,
                    y => y
                );
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await this._dbContext
                .Artists
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
