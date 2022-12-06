using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces;

public interface IItemService
{
    Task<List<Item>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Item> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
