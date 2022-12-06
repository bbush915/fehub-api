using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces;

public interface IAccessoryService
{
    Task<List<Accessory>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Accessory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
