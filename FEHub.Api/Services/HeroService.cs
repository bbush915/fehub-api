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

public sealed class HeroService : IHeroService
{
    private readonly FehContext _dbContext;

    public HeroService(FehContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task<List<Hero>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return this._dbContext
            .Heroes
            .ToListAsync(cancellationToken);
    }

    public Task<Hero> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return this._dbContext
            .Heroes
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<Hero>> QueryByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return this._dbContext
            .Heroes
            .Where(x => x.Name.Contains(name))
            .ToListAsync(cancellationToken);
    }
}
