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

public sealed class SkillMovementTypeService : ISkillMovementTypeService
{
    private readonly FehContext _dbContext;

    public SkillMovementTypeService(FehContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task<ILookup<Guid, SkillMovementType>> GetBySkillIdsAsync(IEnumerable<Guid> skillIds, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            this._dbContext
                .SkillMovementTypes
                .Where(x => skillIds.Contains(x.SkillId))
                .ToLookup(x => x.SkillId)
        );
    }
}
