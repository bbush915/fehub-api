//-----------------------------------------------------------------------------
// <copyright file="VoiceActorService.cs">
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
    internal sealed class VoiceActorService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public VoiceActorService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<VoiceActor>> GetAllAsync()
        {
            return await this._dbContext
                .VoiceActors
                .ToListAsync();
        }

        public async Task<IDictionary<int, VoiceActor>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            return await this._dbContext
                .VoiceActors
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(
                    x => x.Id,
                    y => y
                );
        }

        public async Task<VoiceActor> GetByIdAsync(int id)
        {
            return await this._dbContext
                .VoiceActors
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
