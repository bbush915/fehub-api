//-----------------------------------------------------------------------------
// <copyright file="HeroVoiceActorService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    public sealed class HeroVoiceActorService : IHeroVoiceActorService
    {
        private readonly FehContext _dbContext;

        public HeroVoiceActorService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<ILookup<Guid, HeroVoiceActor>> GetByHeroIdsAsync(IEnumerable<Guid> heroIds, Languages language, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(
                this._dbContext
                    .HeroVoiceActors
                    .Where(
                        x =>
                            heroIds.Contains(x.HeroId) &&
                            (x.Language == language)
                    )
                    .ToLookup(x => x.HeroId)
            );
        }
    }
}
