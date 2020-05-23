//-----------------------------------------------------------------------------
// <copyright file="HeroSkillService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    internal sealed class HeroSkillService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public HeroSkillService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public Task<ILookup<Guid, HeroSkill>> GetByHeroIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                this._dbContext
                    .HeroSkills
                    .Where(x => ids.Contains(x.HeroId))
                    .ToLookup(x => x.HeroId)
            );
        }
        #endregion
    }
}
