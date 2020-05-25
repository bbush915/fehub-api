//-----------------------------------------------------------------------------
// <copyright file="HeroVoiceActorService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    internal sealed class HeroVoiceActorService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public HeroVoiceActorService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Gets a curried <see cref="GetByHeroIds(IEnumerable{Guid}, Languages)"/> to filter by the given language.
        /// </summary>
        /// <param name="language">
        ///     The language filter.
        /// </param>
        /// <returns>
        ///     A curried version of <see cref="GetByHeroIds(IEnumerable{Guid}, Languages)"/>.
        /// </returns>
        public Func<IEnumerable<Guid>, CancellationToken, Task<ILookup<Guid, HeroVoiceActor>>> GetByHeroIdsAsync(Languages language)
        {
            return (IEnumerable<Guid> ids, CancellationToken cancellationToken) => Task.FromResult(this.GetByHeroIds(ids, language));
        }

        public ILookup<Guid, HeroVoiceActor> GetByHeroIds(IEnumerable<Guid> ids, Languages language)
        {
            return this._dbContext
                .HeroVoiceActors
                .Where(
                    x =>
                        ids.Contains(x.HeroId) &&
                        (x.Language == language)
                )
                .ToLookup(x => x.HeroId);
        }
        #endregion
    }
}
