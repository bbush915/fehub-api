using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces;

public interface IArtistService
{
    Task<List<Artist>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IDictionary<int, Artist>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);

    Task<Artist> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
