using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services;

public sealed class AccessoryService : IAccessoryService
{
    private readonly FehContext _dbContext;

    public AccessoryService(FehContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task<List<Accessory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return this._dbContext
            .Accessories
            .ToListAsync(cancellationToken);
    }

    public Task<Accessory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return this._dbContext
            .Accessories
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
