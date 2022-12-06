using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services;

public sealed class VoiceActorService : IVoiceActorService
{
    private readonly FehContext _dbContext;

    public VoiceActorService(FehContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task<List<VoiceActor>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return this._dbContext
            .VoiceActors
            .ToListAsync(cancellationToken);
    }

    public async Task<IDictionary<int, VoiceActor>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
    {
        return await this._dbContext
            .VoiceActors
            .Where(x => ids.Contains(x.Id))
            .ToDictionaryAsync(k => k.Id, v => v, cancellationToken);
    }

    public Task<VoiceActor> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return this._dbContext
            .VoiceActors
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
