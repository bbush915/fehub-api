//-----------------------------------------------------------------------------
// <copyright file="IHeroVoiceActorService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces
{
    public interface IHeroVoiceActorService
    {
        /// <summary>
        ///     Gets a curried <see cref="GetByHeroIds(IEnumerable{Guid}, Languages, CancellationToken)"/> to filter by the given language.
        /// </summary>
        /// <param name="language">
        ///     The language filter.
        /// </param>
        /// <returns>
        ///     A curried version of <see cref="GetByHeroIds(IEnumerable{Guid}, Languages, CancellationToken)"/>.
        /// </returns>
        Func<IEnumerable<Guid>, CancellationToken, Task<ILookup<Guid, HeroVoiceActor>>> GetByHeroIdsAsync(Languages language)
        {
            return (IEnumerable<Guid> heroIds, CancellationToken cancellationToken) => this.GetByHeroIdsAsync(heroIds, language, cancellationToken);
        }

        Task<ILookup<Guid, HeroVoiceActor>> GetByHeroIdsAsync(IEnumerable<Guid> heroIds, Languages language, CancellationToken cancellationToken = default);
    }
}
