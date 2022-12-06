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

public sealed class SkillWeaponEffectivenessService : ISkillWeaponEffectivenessService
{
    private readonly FehContext _dbContext;

    public SkillWeaponEffectivenessService(FehContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task<ILookup<Guid, SkillWeaponEffectiveness>> GetBySkillIdsAsync(IEnumerable<Guid> skillIds, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            this._dbContext
                .SkillWeaponEffectivenesses
                .Where(x => skillIds.Contains(x.SkillId))
                .ToLookup(x => x.SkillId)
        );
    }
}
