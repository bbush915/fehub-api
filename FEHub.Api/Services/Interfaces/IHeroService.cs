//-----------------------------------------------------------------------------
// <copyright file="IHeroService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces
{
    public interface IHeroService
    {
        Task<List<Hero>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Hero> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
