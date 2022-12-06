using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services;

public sealed class HeroSkillService : IHeroSkillService
{
    private readonly FehContext _dbContext;

    public HeroSkillService(FehContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task<ILookup<Guid, HeroSkill>> GetByHeroIdsAsync(IEnumerable<Guid> heroIds, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            this._dbContext
                .HeroSkills
                .Where(x => heroIds.Contains(x.HeroId))
                .ToLookup(x => x.HeroId)
        );
    }
}
