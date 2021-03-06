﻿//-----------------------------------------------------------------------------
// <copyright file="IVoiceActorService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces
{
    public interface IVoiceActorService
    {
        Task<List<VoiceActor>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IDictionary<int, VoiceActor>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);

        Task<VoiceActor> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
