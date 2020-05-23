//-----------------------------------------------------------------------------
// <copyright file="SkillWeaponEffectivenessService.cs">
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
    internal sealed class SkillWeaponEffectivenessService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public SkillWeaponEffectivenessService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public Task<ILookup<Guid, SkillWeaponEffectiveness>> GetBySkillIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                this._dbContext
                    .SkillWeaponEffectivenesses
                    .Where(x => ids.Contains(x.SkillId))
                    .ToLookup(x => x.SkillId)
            );
        }
        #endregion
    }
}
